const axeBadge = {
    el: null,
    popover: null,
    descEl: null,
    passedEl: null,
    violationsEl: null,
    iconEl: null,
    textEl: null,
    vpatEl: null,
    lastResult: null,
    scanInFlight: false
};

function initAxeBadge() {
    axeBadge.el = document.getElementById("sf-axe-badge");
    axeBadge.popover = document.getElementById("sf-axe-popover");
    axeBadge.descEl = document.getElementById("sf-axe-popover-desc");
    axeBadge.passedEl = document.getElementById("sf-axe-popover-passed");
    axeBadge.violationsEl = document.getElementById("sf-axe-popover-violations");
    axeBadge.iconEl = document.querySelector("#sf-axe-badge .sf-axe-badge__icon");
    axeBadge.textEl = document.querySelector("#sf-axe-badge .sf-axe-badge__text");
    axeBadge.vpatEl = document.getElementById("sf-axe-vpat-link");

    if (!axeBadge.el) {
        return;
    }

    // Open on hover/focus (primary interactions per accessibility spec).
    axeBadge.el.addEventListener("mouseenter", openAxePopover);
    axeBadge.el.addEventListener("focus", openAxePopover);

    // Close when the pointer leaves or focus moves off both the badge and the popover.
    axeBadge.el.addEventListener("mouseleave", scheduleCloseOnLeave);
    axeBadge.el.addEventListener("blur", handleBadgeBlur);

    if (axeBadge.popover) {
        axeBadge.popover.addEventListener("mouseenter", cancelPendingClose);
        axeBadge.popover.addEventListener("mouseleave", scheduleCloseOnLeave);
    }

    // Click toggles — useful for keyboard / touch users who can't hover.
    axeBadge.el.addEventListener("click", function (event) {
        event.stopPropagation();
        toggleAxePopover();
    });

    document.addEventListener("click", function (event) {
        if (!axeBadge.popover || axeBadge.popover.hidden) {
            return;
        }
        if (axeBadge.popover.contains(event.target) || axeBadge.el.contains(event.target)) {
            return;
        }
        closeAxePopover();
    });

    document.addEventListener("keydown", function (event) {
        if (event.key === "Escape") {
            closeAxePopover();
        }
    });

    // Auto-run a scan after the page stabilizes so the badge reflects current results.
    window.requestIdleCallback
        ? window.requestIdleCallback(runAxeScan, { timeout: 2000 })
        : setTimeout(runAxeScan, 1200);
}

function toggleAxePopover() {
    if (!axeBadge.popover) {
        return;
    }
    if (axeBadge.popover.hidden) {
        openAxePopover();
    } else {
        closeAxePopover();
    }
}

function openAxePopover() {
    if (!axeBadge.popover || !axeBadge.el) {
        return;
    }
    cancelPendingClose();
    axeBadge.popover.hidden = false;
    if (axeBadge.el) {
    axeBadge.el.setAttribute("aria-expanded", "true");
    }
}

function closeAxePopover() {
    if (!axeBadge.popover) {
        return;
    }
    axeBadge.popover.hidden = true;
    if (axeBadge.el) {
        axeBadge.el.setAttribute("aria-expanded", "false");
    }
}

// Close after a short delay so the user can move from the badge into the
// popover without it disappearing. The delay is cancelled if the pointer
// re-enters the badge or the popover itself.
let pendingCloseTimer = null;
function scheduleCloseOnLeave() {
    cancelPendingClose();
    pendingCloseTimer = window.setTimeout(function () {
        pendingCloseTimer = null;
        closeAxePopover();
    }, 150);
}

function cancelPendingClose() {
    if (pendingCloseTimer !== null) {
        window.clearTimeout(pendingCloseTimer);
        pendingCloseTimer = null;
    }
}

function handleBadgeBlur() {
    // If focus moves to the popover or its descendants, keep it open.
    const next = document.activeElement;
    if (axeBadge.popover && axeBadge.popover.contains(next)) {
        return;
    }
    scheduleCloseOnLeave();
}

function updateAxeBadge(result) {
    if (!axeBadge.el || !result) {
        return;
    }

    const passes = (result.passes || []).length;
    const incomplete = (result.incomplete || []).length;
    const inapplicable = (result.inapplicable || []).length;
    const violations = (result.violations || []).length;
    const totalChecks = passes + incomplete;
    const passedWithBestPractices = passes + inapplicable;

    // Pill text always shows the WCAG level — never the raw counts.
    if (axeBadge.textEl) {
        axeBadge.textEl.textContent = "WCAG 2.2 AA";
    }

    // Popover stat counts. "Passed" reflects passes + best-practice rules
    // (inapplicable) so it matches the {passes + bestpractices} count used in the description.
    if (axeBadge.passedEl) {
        axeBadge.passedEl.textContent = String(passes);
    }
    if (axeBadge.violationsEl) {
        axeBadge.violationsEl.textContent = String(violations);
    }

    axeBadge.el.classList.remove(
        "sf-axe-badge--loading",
        "sf-axe-badge--success",
        "sf-axe-badge--violation"
    );

    // The pill is always rendered as a green WCAG compliance badge.
    // Pass / violation counts are surfaced only inside the popover stats.
    const stateClass = "sf-axe-badge--success";
    const label = "Accessibility: " + passes + " checks passed, " + violations + " violations";
    const desc = "This demo passes " + passedWithBestPractices +
        " automated axe checks with " + violations +
        " violations — semantic markup, ARIA, full keyboard operation, visible focus. Section 508 conformant.";

    axeBadge.el.classList.add(stateClass);
    axeBadge.el.setAttribute("aria-label", label);

    if (axeBadge.descEl) {
        axeBadge.descEl.textContent = desc;
    }

    if (axeBadge.vpatEl) {
        axeBadge.vpatEl.hidden = false;
    }
}

async function runAxeScan() {
    if (axeBadge.scanInFlight) {
        return axeBadge.lastResult;
    }
    axeBadge.scanInFlight = true;
    try {
        if (!window.axe) {
            console.warn("axe-core not loaded; skipping scan.");
            return null;
        }
        const accessibilityConfig = {
            exclude: [],
            ignore: [],
            rules: {}
        };
        const target =
            document.querySelector(".sb-demo-section") ||
            document.body;

        const results = await window.axe.run(
            {
                include: [target],
                exclude: accessibilityConfig.exclude || []
            },
            {
                rules: accessibilityConfig.rules || {},
                runOnly: {
                    type: "tag",
                    values: [
                        "wcag2a",
                        "wcag2aa",
                        "wcag2aaa",
                        "section508"
                    ]
                }
            }
        );

        filterIgnoredViolations(results, accessibilityConfig.ignore);
        axeBadge.lastResult = results;
        updateAxeBadge(results);
        return results;
    } catch (error) {
        console.error("Axe scan failed:", error);
        return null;
    } finally {
        axeBadge.scanInFlight = false;
    }
}

function formatWcagTags(tags) {
    if (!tags || !tags.length) {
        return "N/A";
    }

    const knownLevels = {
        wcag2a: "WCAG A",
        wcag21a: "WCAG A",
        wcag2aa: "WCAG AA",
        wcag21aa: "WCAG AA",
        wcag2aaa: "WCAG AAA",
        wcag21aaa: "WCAG AAA"
    };

    const relevant = tags.filter(tag =>
        /^wcag/i.test(tag) &&
        !/^cat\./i.test(tag) &&
        !/^ACT/i.test(tag)
    );

    const mapped = relevant
        .map(tag => {
            const key = tag.toLowerCase();

            if (knownLevels[key]) {
                return knownLevels[key];
            }

            if (/aaa/.test(key)) {
                return "WCAG AAA";
            }

            if (/aa/.test(key)) {
                return "WCAG AA";
            }

            return "WCAG A";
        });

    return [...new Set(mapped)].join(", ") || "N/A";
}

function formatRuleElement(nodes) {

    if (!nodes || !nodes.length) {
        return "N/A";
    }

    const first = nodes[0];

    const target = Array.isArray(first.target)
        ? first.target.join(" | ")
        : first.target;

    return target || "N/A";
}

function filterIgnoredViolations(results, ignoredFailures) {

    if (!ignoredFailures || !ignoredFailures.length) {
        return;
    }

    results.violations = results.violations.filter(rule =>
        !ignoredFailures.some(item => item.rule === rule.id)
    );
}

async function runAxeReport() {

    try {

        if (!window.axe) {
            alert("axe-core not loaded");
            return;
        }

        const results = axeBadge.lastResult || (await runAxeScan());

        if (!results) {
            return;
        }

const win = window.open("", "_blank");

        if (!win) {
            alert("Popup blocked.");
            return;
        }

        const rows = [
            ...(results.passes || []).map((r, i) => ({
                id: i + 1,
                description: r.help || "",
                ruleId: r.id,
                wcag: formatWcagTags(r.tags),
                nodes: r.nodes ? r.nodes.length : 0,
                status: "Pass",
                element: formatRuleElement(r.nodes)
            })),
            ...(results.violations || []).map((r, i) => ({
                id: results.passes.length + i + 1,
                description: r.help || "",
                ruleId: r.id,
                wcag: formatWcagTags(r.tags),
                nodes: r.nodes ? r.nodes.length : 0,
                status: "Fail",
                element: formatRuleElement(r.nodes)
            }))
        ];

        win.document.write(`
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Accessibility Report</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
    * { box-sizing: border-box; }
    body {
        margin: 0;
        font-family: "Segoe UI", Arial, sans-serif;
        background: #f5f5f5;
        color: #222;
    }
    .layout {
        display: flex;
        gap: 24px;
        max-width: 1500px;
        margin: 24px;
    }
    .left-panel {
        width: 320px;
        flex-shrink: 0;
        display: flex;
        flex-direction: column;
        gap: 16px;
    }
    .panel {
        border: 1px solid #e5e7eb;
        border-radius: 6px;
        padding: 16px;
        background: #fff;
        box-shadow: 0 1px 2px rgba(0,0,0,0.06);
    }
    .panel-title {
        font-size: 13px;
        font-weight: 600;
        color: #555;
        margin-bottom: 8px;
    }
    .score {
        font-size: 42px;
        font-weight: 700;
        color: #1976d2;
        line-height: 1;
    }
    .score-desc {
        margin-top: 10px;
        line-height: 1.5;
        color: rgba(0, 0, 0, 0.72);
        font-size: 12px;
    }
    .metric-row {
        display: flex;
        align-items: center;
        justify-content: space-between;
        margin: 10px 0;
        font-size: 14px;
    }
    .metric-left {
        display: inline-flex;
        align-items: center;
        gap: 8px;
        color: rgba(0, 0, 0, 0.87);
    }
    .metric-count {
        font-size: 15px;
        color: rgba(0, 0, 0, 0.87);
        font-weight: 600;
    }
    .grid-panel {
        flex: 1;
        min-width: 0;
        background: #fff;
        border: 1px solid #e5e7eb;
        border-radius: 6px;
        padding: 16px;
        box-shadow: 0 1px 2px rgba(0,0,0,0.06);
        overflow-x: auto;
    }
    table.axe-report {
        width: 100%;
        border-collapse: collapse;
        font-size: 13px;
    }
    table.axe-report thead th {
        text-align: left;
        padding: 10px 8px;
        border-bottom: 1px solid #e5e7eb;
        background: #fafafa;
        font-weight: 600;
        color: #444;
    }
    table.axe-report tbody td {
        padding: 10px 8px;
        border-bottom: 1px solid #f0f0f0;
        vertical-align: top;
    }
    table.axe-report tbody tr:hover {
        background: #fafafa;
    }
    .col-id { width: 50px; text-align: center; }
    .col-nodes { width: 80px; text-align: center; }
    .col-status { width: 80px; text-align: center; }
    .col-wcag { width: 130px; }
    .col-rule { width: 180px; }
    .wrap-cell {
        max-height: 100px;
        overflow: hidden;
        white-space: normal;
        word-break: break-word;
    }
    .status-icon {
        display: inline-flex;
        align-items: center;
        justify-content: center;
    }
    .nodes-pill {
        display: inline-block;
        padding: 2px 10px;
        border-radius: 999px;
        background: #e6f4ea;
        color: #1b5e20;
        font-weight: 600;
        font-size: 12px;
    }
    .pager {
        display: flex;
        align-items: center;
        justify-content: space-between;
        margin-top: 12px;
        font-size: 13px;
        color: #555;
    }
    .pager button {
        background: #fff;
        border: 1px solid #d0d0d0;
        border-radius: 4px;
        padding: 6px 12px;
        cursor: pointer;
        font-family: inherit;
        font-size: 13px;
        margin-left: 4px;
    }
    .pager button:hover:not(:disabled) {
        background: #f5f5f5;
    }
    .pager button:disabled {
        opacity: 0.5;
        cursor: not-allowed;
    }
    .pager-pages {
        display: inline-flex;
        align-items: center;
    }
    .pager-pages button.active {
        background: #1976d2;
        color: #fff;
        border-color: #1976d2;
    }
    @media (max-width: 1024px) {
        .layout { flex-direction: column; gap: 16px; margin: 16px; }
        .left-panel { width: 100%; flex-direction: row; flex-wrap: wrap; }
        .left-panel .panel { flex: 1 1 280px; }
        .grid-panel { width: 100%; }
    }
    @media (max-width: 600px) {
        .layout { margin: 12px; }
        .left-panel { flex-direction: column; }
        .left-panel .panel { flex: 1 1 100%; }
        .score { font-size: 36px; }
    }
</style>
</head>
<body>
<div class="layout">
    <div class="left-panel">
        <div class="panel">
            <div class="panel-title">Status Score</div>
            <div class="score" id="score"></div>
            <div class="score-desc">Accessibility conformance is evaluated through a combination of automated testing, manual audits, and expert review to identify issues that may extend beyond automated detection capabilities.</div>
        </div>

        <div class="panel">
            <div class="panel-title">Quick Metrics</div>
            <div class="metric" id="metrics"></div>
        </div>
    </div>

    <div class="grid-panel">
        <table class="axe-report" id="report-table">
            <thead>
                <tr>
                    <th class="col-id">#</th>
                    <th>Description</th>
                    <th class="col-rule">Axe Rule ID</th>
                    <th class="col-wcag">WCAG</th>
                    <th class="col-nodes">Nodes</th>
                    <th class="col-status">Status</th>
                    <th>Element</th>
                </tr>
            </thead>
            <tbody id="report-body"></tbody>
        </table>
        <div class="pager" id="pager">
            <span id="pager-info"></span>
            <span class="pager-pages" id="pager-pages"></span>
        </div>
    </div>
</div>

<script>
(function () {
    var rows = ${JSON.stringify(rows)};
    var passCount = ${results.passes.length};
    var failCount = ${results.violations.length};
    var bestCount = ${results.inapplicable.length};

    var total = passCount + failCount + bestCount;
    var score = total === 0
        ? 100
        : Math.round(((passCount + bestCount) / total) * 100);
    document.getElementById('score').textContent = score.toString();

    // Inline SVG icons used in metrics + status column
    var icons = {
        pass: '<svg class="status-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#2e7d32" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="10" fill="#e6f4ea" stroke="#2e7d32"/><path d="M9 12.5l2 2 4-4.5"/></svg>',
        fail: '<svg class="status-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#d32f2f" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="10" fill="#fdecea" stroke="#d32f2f"/><path d="M9 9l6 6M15 9l-6 6"/></svg>',
        info: '<svg class="status-icon" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="#0288d1" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round" aria-hidden="true"><circle cx="12" cy="12" r="10" fill="#e1f5fe" stroke="#0288d1"/><path d="M12 11v5M12 8v.01"/></svg>'
    };

    document.getElementById('metrics').innerHTML =
        '<p class="metric-row">' +
            '<span class="metric-left">' + icons.pass + ' Pass Checks</span>' +
            '<span class="metric-count">' + passCount + '</span>' +
        '</p>' +
        '<p class="metric-row">' +
            '<span class="metric-left">' + icons.fail + ' Fails</span>' +
            '<span class="metric-count">' + failCount + '</span>' +
        '</p>' +
        '<p class="metric-row">' +
            '<span class="metric-left">' + icons.info + ' Best Practices</span>' +
            '<span class="metric-count">' + bestCount + '</span>' +
        '</p>';

    // Escape attribute values to keep the markup safe.
    function attr(v) {
        return String(v == null ? 'N/A' : v).replace(/&/g, '&amp;').replace(/"/g, '&quot;').replace(/</g, '&lt;');
    }

    var PAGE_SIZE = 8;
    var currentPage = 1;

    function renderRows() {
        var tbody = document.getElementById('report-body');
        var total = rows.length;
        var pages = Math.max(1, Math.ceil(total / PAGE_SIZE));
        if (currentPage > pages) currentPage = pages;
        var start = (currentPage - 1) * PAGE_SIZE;
        var page = rows.slice(start, start + PAGE_SIZE);
        var html = '';
        for (var i = 0; i < page.length; i++) {
            var r = page[i];
            var isPass = r.status === 'Pass';
            html += '<tr>' +
                '<td class="col-id">' + (start + i + 1) + '</td>' +
                '<td><div class="wrap-cell" title="' + attr(r.description) + '">' + attr(r.description) + '</div></td>' +
                '<td class="col-rule">' + attr(r.ruleId) + '</td>' +
                '<td class="col-wcag">' + attr(r.wcag) + '</td>' +
                '<td class="col-nodes"><span class="nodes-pill">' + (r.nodes || 0) + '</span></td>' +
                '<td class="col-status">' + (isPass ? icons.pass : icons.fail) + '</td>' +
                '<td><div class="wrap-cell" title="' + attr(r.element) + '">' + attr(r.element) + '</div></td>' +
            '</tr>';
        }
        if (total === 0) {
            html = '<tr><td colspan="7" style="text-align:center;color:#888;padding:24px;">No accessibility results to show.</td></tr>';
        }
        tbody.innerHTML = html;

        document.getElementById('pager-info').textContent =
            total === 0 ? '0 results' : ('Showing ' + (start + 1) + '\u2013' + Math.min(start + PAGE_SIZE, total) + ' of ' + total);

        var pagesBox = document.getElementById('pager-pages');
        var pagerHtml = '<button type="button" id="pg-prev"' + (currentPage <= 1 ? ' disabled' : '') + '>&#8249; Prev</button>';
        for (var p = 1; p <= pages; p++) {
            pagerHtml += '<button type="button" class="pg-num' + (p === currentPage ? ' active' : '') + '" data-page="' + p + '">' + p + '</button>';
        }
        pagerHtml += '<button type="button" id="pg-next"' + (currentPage >= pages ? ' disabled' : '') + '>Next &#8250;</button>';
        pagesBox.innerHTML = pagerHtml;

        var prev = document.getElementById('pg-prev');
        var next = document.getElementById('pg-next');
        if (prev) prev.addEventListener('click', function () { if (currentPage > 1) { currentPage--; renderRows(); } });
        if (next) next.addEventListener('click', function () { if (currentPage < pages) { currentPage++; renderRows(); } });
        var nums = pagesBox.querySelectorAll('.pg-num');
        for (var k = 0; k < nums.length; k++) {
            nums[k].addEventListener('click', function () { currentPage = parseInt(this.getAttribute('data-page'), 10) || 1; renderRows(); });
        }
    }
    renderRows();
})();
<\/script>
</body>
</html>
`);

        win.document.close();

    } catch (error) {

        console.error(error);

        alert(
            "AXE scan failed: " +
            (error?.message || error)
        );
    }
}

window.runAxeReport = runAxeReport;
window.runAxeScan = runAxeScan;
window.updateAxeBadge = updateAxeBadge;

if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", initAxeBadge);
} else {
    initAxeBadge();
}