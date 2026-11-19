var switcherPopup;
var themeSwitherPopup;
var sdkSwitherPopup;
var openedPopup;
var searchPopup;
var settingsPopup;
var prevAction;
var ArrayItem;
var items = [];
var searchInstance;
var isStaging = document.body.dataset.isStaging === "true";
var headerThemeSwitch = document.getElementById('header-theme-switcher');
var headerSdkSwitch = document.getElementById('header-sdk-switcher');
var settingElement = ej.base.select('.sb-setting-btn');
var notificationElement = ej.base.select('.sb-notification-btn');
var themeList = document.getElementById('themelist');
var themes = isStaging ? ['material', 'material3', 'fabric', 'fluent', 'fluent2', 'bootstrap', 'bootstrap4', 'bootstrap5', 'bootstrap5.3', 'tailwind', 'tailwind3', 'highcontrast', 'fluent2-highcontrast'] : ['material3', 'bootstrap5.3', 'fluent2', 'tailwind3', 'fluent2-highcontrast'] ;
var themeIndex = isStaging ? { 'material': 0, 'material3': 1, 'fabric': 2, 'fluent': 3, 'fluent2': 4, 'bootstrap': 5, 'bootstrap4': 6, 'bootstrap5': 7, 'bootstrap5.3': 8, 'tailwind': 9, 'tailwind3': 10, 'highcontrast': 11, 'fluent2-highcontrast': 12 } : { 'material3': 0, 'bootstrap5.3': 1, 'fluent2': 2, 'tailwind3': 3, 'fluent2-highcontrast': 4 };
var themeMode_Index =  isStaging ? { 'material': 'Material', 'material3': 'Material 3', 'fabric': 'Fabric', 'fluent': 'Fluent', 'fluent2': 'Fluent 2', 'bootstrap': 'Bootstrap', 'bootstrap4': 'Bootstrap v4', 'bootstrap5': 'Bootstrap v5', 'bootstrap5.3': 'Bootstrap 5.3',  'highcontrast': 'High Contrast', 'fluent2-highcontrast': 'Fluent 2 High Contrast', 'tailwind': 'Tailwind CSS', 'tailwind3': 'Tailwind3 CSS' } : { 'material3': 'Material 3', 'bootstrap5.3': 'Bootstrap 5', 'fluent2': 'Fluent 2', 'tailwind3': 'Tailwind CSS', 'fluent2-highcontrast': 'Fluent 2 High Contrast' };
var cultureData = { "English": "en", "German - Germany*": "de", "French - Switzerland*": "fr-CH", "Arabic*": "ar", "Chinese - China*":"zh" };
var defaultTheme = 'fluent2';
var themeDropDown;
var contentTab;
var sourceTab;
var isExternalNavigation = true;
var defaultTree = false;
var intialLoadCompleted = false;
var resizeManualTrigger = false;
var leftToggle = ej.base.select('#sb-toggle-left');
var sbRightPane = ej.base.select('.sb-right-pane');
var sbContentOverlay = ej.base.select('.sb-content-overlay');
var sbBodyOverlay = ej.base.select('.sb-body-overlay');
var sbHeader = ej.base.select('#sample-header');
var resetSearch = ej.base.select('.sb-reset-icon');
var urlRegex = /(npmci\.syncfusion\.com|ej2\.syncfusion\.com)(\/)(development|production)*/;
var sampleRegex = /#\/(([^\/]+\/)+[^\/\.]+)/;
//Regex for removing hidden
var reg = /.*custom code start([\S\s]*?)custom code end.*/g;
var sbArray = ['angular', 'react', 'typescript', 'javascript', 'aspnetmvc', 'vue', 'blazor'];
var sbObj = {
    'angular': 'angular',
    'typescript': '',
    'react': 'react',
    'javascript': 'javascript',
    'aspnetmvc': 'aspnetmvc',
    'vue': 'vue',
    'blazor': 'blazor'
};
var searchEle = ej.base.select('#search-popup');
var inputele = ej.base.select('#search-input');
var searchOverlay = ej.base.select('.e-search-overlay');
var searchButton = document.getElementById('sb-trigger-search');
var setResponsiveElement = ej.base.select('.setting-responsive');
var isMobile = window.matchMedia('(max-width:550px)').matches;
var isTablet = window.matchMedia('(min-width:600px) and (max-width: 850px)').matches;
var isPc = window.matchMedia('(min-width:850px)').matches;
var selectedTheme = location.hash.split('/')[1] || defaultTheme;
var controlSampleData = {};
var samplesList = getSampleList();
var samplesTreeList = [];
var execFunction = {};
var searchListView;
//window.apiList = window.apiList;
var sampleNameElement = document.querySelector('#component-name>.sb-sample-text');
var breadCrumbComponent = document.querySelector('.sb-bread-crumb-text>.category-text');
var breadCrumSeperator = ej.base.select('.category-seperator');
var breadCrumbSubCategory = document.querySelector('.sb-bread-crumb-text>.component');
var breadCrumbSample = document.querySelector('.sb-bread-crumb-text>.crumb-sample');
var apiGrid;
window.navigateSample = (window.navigateSample !== undefined) ? window.navigateSample : function () { return; };
var isInitRedirected;
var samplePath = [];
var samplesAr = [];
var currentControlID;
var currentSampleID;
var currentControl;
var cultureDropDown;
var matchedCurrency = {
    'en': 'USD',
    'de': 'EUR',
    'ar': 'AED',
    'zh': 'CNY',
    'fr-CH': 'CHF'
};
var newYear = new Date().getFullYear();
var copyRight = document.querySelector('.sb-footer-copyright');
copyRight.innerHTML = "Copyright &copy 2001 - " + newYear + " Syncfusion<sup>&reg;</sup> Inc.";
if(ej.base.registerLicense != undefined){
	ej.base.registerLicense('');
}
let isPropertyPanelOpen = true;
function preventTabSwipe(e) {
    if (e.isSwiped) {
        e.cancel = true;
    }
}

function sourceTabSelected(e) {
    if (e.isSwiped) {
        e.cancel = true;
    }
    var sourceEle = document.querySelector('#sb-source-tab > .e-content > #e-content' + this.tabId + '_' + e.selectedIndex).children[0];
    sourceEle.innerHTML = items[e.selectedIndex].data;
    sourceEle.innerHTML = sourceEle.innerHTML.replace(reg, '');
    sourceEle.classList.add('sb-src-code');
    sourceEle.style.height = "500px";
    sourceEle.style.overflowY = "auto";
    sourceEle.setAttribute("tabindex", "0");
    hljs.highlightBlock(sourceEle);
}

function changeCulture(cul) {
    if (cul === 'ar') {
        changeRtl();
    }  
    var cur = localStorage.getItem('ej2-currency') ? localStorage.getItem('ej2-currency'): matchedCurrency[cul];
    localStorage.setItem('dropdownlistsb-setting-currency', '{"value":"' + cur + '"}');
    ej.base.setCurrencyCode(cur);
    var culKey = Object.keys(cultureData).find(k => cultureData[k] === cul);
    localStorage.setItem('dropdownlistsb-setting-culture', '{"value":"' + culKey + '"}');
    ej.base.setCulture(cul);
}

function loadCulture() {
    var cul = localStorage.getItem('ej2-culture') || 'en';
    if (cul !== 'en') {
        var locale = new ej.base.Ajax('../scripts/locale/' + cul + '.json', 'GET', false);
        locale.send().then(function (value) {
            ej.base.L10n.load(JSON.parse(value));
        });
    }
    var ajax = new ej.base.Ajax('../scripts/cldr-data/main/' + cul + '/all.json', 'GET', false);
    ajax.send().then(function (result) {
        ej.base.loadCldr(JSON.parse(result));
        changeCulture(cul);
    });
}

function settingPopupHide(hideElementID) {
    if (document.querySelector(hideElementID).ej2_instances[0].element.classList.contains("e-popup-open")) {
        document.querySelector(hideElementID).ej2_instances[0].element.classList.remove("e-popup-open");
        document.querySelector(hideElementID).ej2_instances[0].element.classList.add("e-popup-close");
    }
}

function sbCulture(e) {
    localStorage.setItem('ej2-culture', cultureData[e.value]);
    localStorage.setItem('ej2-culture-name', e.value);
    localStorage.removeItem('ej2-currency');
    settingPopupHide('#sb-setting-culture_popup');
    location.reload();
}

function sbCurrency(e) {
    ej.base.setCurrencyCode(e.value);
    localStorage.setItem('ej2-currency', e.value);
    localStorage.setItem('dropdownlistsb-setting-currency', '{"value":"'+e.value+'"}');
    settingPopupHide('#sb-setting-currency_popup');
}

function setIndex() {
    themeDropDown = document.getElementById('sb-setting-theme');
    var currentURL_index = window.location.href;
    var updatedTheme = "";

    if (currentURL_index.includes("#/")) {
        var hashValue = currentURL_index.split("#/")[1];
        if (!hashValue.includes("-dark")) {
            updatedTheme = hashValue;
            document.getElementById('sb-setting-theme').ej2_instances[0].index = themeIndex[updatedTheme] || 0;
        } else {
            updatedTheme = hashValue.replace("-dark", "");

            var dropdownTheme = document.getElementById('sb-setting-theme');
            var element = document.getElementById('themeMobile');
            var mobileModeThemeDropDownStyle = window.getComputedStyle(element);

            if (mobileModeThemeDropDownStyle.display === "block") {
                dropdownTheme.ej2_instances[0].index = themeIndex[updatedTheme] || 0;
            }
            dropdownTheme.value = themeMode_Index[updatedTheme];
             //document.getElementById('sb-setting-mode').ej2_instances[0].index = 1
        }
    }
    //document.getElementById('sb-setting-theme').ej2_instances[0].index = localStorage.getItem('theme-index') || 0;
    // localStorage.removeItem('theme-index');
}

function getPreferences() {
    settingsPopup = document.getElementById('settings-popup').ej2_instances[0];
}

function getThemeSwitcher() {
    themeSwitherPopup = document.getElementById('theme-switcher-popup').ej2_instances[0];
}

function getSdkSwitcher() {
    sdkSwitherPopup = document.getElementById('sdk-switcher-popup').ej2_instances[0];
    // Read SDK from URL query string. The query parameter is the single source of truth.
    // 'UIEdition' is a special pseudo-SDK that represents "no SDK filter" — it is never
    // expected in the URL query string; selecting it strips the sdk param entirely.
    // 'StandaloneGroup' is a non-selectable group header (the parent of the standalone SDKs)
    // and is therefore NOT in knownIds.
    var knownIds = ['UIEdition', 'Grid', 'Charts', 'Diagram', 'Gantt', 'FileManager', 'Scheduler', 'RichTextEditor'];
    var labelMap = {
        'UIEdition': 'All Demos',
        'Grid': 'Grid SDK',
        'Charts': 'Chart SDK',
        'Diagram': 'Diagram SDK',
        'Gantt': 'Gantt SDK',
        'FileManager': 'File Manager SDK',
        'Scheduler': 'Scheduler SDK',
        'RichTextEditor': 'Rich Text Editor SDK'
    };
    var urlParams = new URLSearchParams(window.location.search);
    var rawSdk = urlParams.get('sdk');
    var currentSdk = null;
    var isUiEdition = !rawSdk;
    if (rawSdk) {
        // Try to match the raw value (case-insensitive) to one of the known SDK ids.
        for (var k = 0; k < knownIds.length; k++) {
            if (knownIds[k].toLowerCase() === rawSdk.toLowerCase()) {
                currentSdk = knownIds[k];
                break;
            }
        }
    }
    // If sdk query param is invalid, remove the invalid value from the URL and reload
    // so the page loads with no active SDK selection in the dropdown.
    if (!currentSdk && rawSdk) {
        var cleanUrl = new URL(window.location.href);
        cleanUrl.searchParams.delete('sdk');
        window.location.replace(cleanUrl.toString());
        return; // Stop further processing; the page will reload.
    }
    var sdkList = document.getElementById('sdklist');
    if (sdkList) {
        var items = sdkList.querySelectorAll('li');
        for (var i = 0; i < items.length; i++) {
            // Don't clear the active state of the StandaloneGroup parent
            // (it's not a selectable item but a group header).
            if (items[i].id !== 'StandaloneGroup') {
                items[i].classList.remove('active');
            }
        }
        // Mark the active item based on the URL. 'UIEdition' is active when the URL
        // has no sdk query param; otherwise the matching SDK id is active.
        var activeId = currentSdk || (isUiEdition ? 'UIEdition' : null);
        var activeLabel = '';
        if (activeId) {
            for (var j = 0; j < items.length; j++) {
                if (items[j].id === activeId) {
                    items[j].classList.add('active');
                    var labelSpan = items[j].querySelector('.switch-text');
                    if (labelSpan) {
                        activeLabel = labelSpan.textContent.trim();
                    }
                    break;
                }
            }
        }
        // Bind the active SDK label to the SDK switcher button text.
        var activeText = document.querySelector('#header-sdk-switcher .sb-sdk-active-text');
        if (activeText) {
            activeText.textContent = activeLabel || labelMap['UIEdition'];
        }
        // Also update the mobile secondary header SDK switcher label.
        var mobileActiveText = document.querySelector('#header-sdk-switcher-mobile .sb-sdk-active-text');
        if (mobileActiveText) {
            mobileActiveText.textContent = activeLabel || labelMap['UIEdition'];
        }
        // Auto-expand the Standalone UI SDK group if a child is currently the active selection.
        var group = document.getElementById('StandaloneGroup');
        if (group) {
            var standaloneChildIds = ['Grid', 'Charts', 'Scheduler', 'Gantt', 'RichTextEditor', 'Diagram', 'FileManager'];
            if (standaloneChildIds.indexOf(currentSdk) !== -1) {
                group.setAttribute('aria-expanded', 'true');
            } else {
                group.setAttribute('aria-expanded', 'false');
            }
            // Wire click-to-toggle for the Standalone UI SDK group header. The header
            // itself is not selectable (clicking it should not change the URL/active SDK),
            // only expand/collapse its child items.
            if (!group.dataset.boundToggle) {
                group.dataset.boundToggle = 'true';
                group.addEventListener('click', function (e) {
                    // Don't toggle when the user is actually clicking on a selectable child.
                    var li = e.target;
                    while (li && li !== group && li.parentNode) {
                        li = li.parentNode;
                    }
                    if (li !== group) { return; }
                    e.preventDefault();
                    e.stopPropagation();
                    var expanded = group.getAttribute('aria-expanded') === 'true';
                    group.setAttribute('aria-expanded', expanded ? 'false' : 'true');
                });
            }
        }
        // Document Solutions items are external-only (data-no-active="true") and
        // none of the known SDK ids maps to a Document Solutions child, so the
        // group is always collapsed on initial load. Clicking the group header
        // toggles it (handled in changeSdk).
        var docGroup = document.getElementById('DocumentSolutionsGroup');
        if (docGroup) {
            docGroup.setAttribute('aria-expanded', 'false');
        }
    }
    // Ensure the sdk query param is in sync with the URL. For a real SDK we set it
    // (lowercase). For 'UIEdition' we make sure no sdk param is present.
    if (currentSdk) {
        var expectedSdkParam = currentSdk.toLowerCase();
        if (!rawSdk || rawSdk.toLowerCase() !== expectedSdkParam) {
            var newUrl = new URL(window.location.href);
            newUrl.searchParams.set('sdk', expectedSdkParam);
            window.history.replaceState({}, '', newUrl.toString());
        }
    } else if (isUiEdition && rawSdk) {
        var cleanUrl2 = new URL(window.location.href);
        cleanUrl2.searchParams.delete('sdk');
        window.history.replaceState({}, '', cleanUrl2.toString());
    }
}

function getToastObj() {
    toastObj = document.getElementById('toast-element').ej2_instances[0];
    if (ej.base.Browser.isDevice) {
        var tempList = ej.base.extend([], window.samplesList);
        for (var i = 0; i < tempList.length; i++) {
            var temp = tempList[i];
            if (temp.hideOnDevice == true) {
                if (temp.name == location.href.split('/').splice(-3, 1).join('/')) {
                    setTimeout(function () {
                        toastObj.show({
                            content: location.href.split('/').splice(-3, 1)[0] + ' component not supported in mobile device'
                        });
                    }, 200);
                    setTimeout(function () {
                        location.href = location.origin + getPathName() + `grid/gridoverview` + getSdkQueryString() + `#/` + getThemeName();
                    }, 2000)
                }
                continue;
            }
        }
    }
}

function getSBSwitcher() {
    switcherPopup = document.getElementById('sb-switcher-popup').ej2_instances[0];
    document.getElementById('switch-sb').addEventListener('click', function (e) {
        var target = ej.base.closest(e.target, 'li');
        if (target) {
            var anchor = target.querySelector('a');
            if (anchor) {
                anchor.click();
            }
        }
    });
}

function getSBSearch() {
    searchPopup = document.getElementById('search-popup').ej2_instances[0];
}

function getSearchValue() {
    var searchValue = ej.base.select('#search-input').value;
    highlight(searchValue, searchListView.element);
}

function initSearchData() {
    searchListView = document.getElementById('search-result-list').ej2_instances[0];
}

function setSamplelist() {
    var listViewData = ej.base.select('#controlList').ej2_instances[0];
    // Ensure listViewData.dataSource exists and has content before accessing it
    if (listViewData && listViewData.dataSource && listViewData.dataSource.length > 0) {
        var firstItemDir = listViewData.dataSource[0].dir.toLowerCase();
        if (controlSampleData[firstItemDir]) {
            listViewData.dataSource = controlSampleData[firstItemDir];
        } else {
            // Fallback if the component is not in controlSampleData
            listViewData.dataSource = [];
        }
    } else {
        // Fallback to current pathname or default to Button
        var defaultControl = location.pathname.split('/').slice(-2)[0];
        listViewData.dataSource = controlSampleData[defaultControl] || controlSampleData['button'] || [];
    }
}

function setTreeData() {
    var treeViewData = ej.base.select('#controlTree').ej2_instances[0];
    treeViewData.fields.dataSource = samplesTreeList;
    // After treeview is loaded, populate the listview with samples from the first component
    if (samplesTreeList && samplesTreeList.length > 0) {
        setTimeout(function () {
            initializeListView();
        }, 100);
    }
}

function initializeListView() {
    var listView = ej.base.select('#controlList').ej2_instances[0];
    if (!listView) return;

    // Check if the listview already has data
    if (listView.dataSource && listView.dataSource.length > 0) {
        return;
    }

    // If samplesList is filtered and has components, use the first one
    if (samplesList && samplesList.length > 0) {
        var firstComponent = samplesList[0];
        var dirKey = firstComponent.directory.toLowerCase();
        if (controlSampleData[dirKey]) {
            listView.dataSource = controlSampleData[dirKey];
            return;
        }
    }

    // Fallback to current pathname or default
    var defaultControl = location.pathname.split('/').slice(-2)[0];
    if (controlSampleData[defaultControl]) {
        listView.dataSource = controlSampleData[defaultControl];
    } else if (controlSampleData['button']) {
        listView.dataSource = controlSampleData['button'];
    }
}

function changeRtl() {
	setTimeout(function() {
		var elementlist = ej.base.selectAll('.e-control', document.getElementById('control-content'));
		var propertylist =[].concat(ej.base.selectAll('.property-section .e-control', document.getElementById('control-content')));
		for (var i = 0; i < elementlist.length; i++) {
            var control = elementlist[i];
            if (propertylist.indexOf(control) === -1) {
                if (control.classList.contains('e-richtexteditor')) {
                    control.ej2_instances = control.getElementsByTagName("textArea")[0].ej2_instances;
                }
                if (control.ej2_instances) {
					for (var a = 0; a < control.ej2_instances.length; a++) {
						var instance = control.ej2_instances[a];
						instance.enableRtl = true;
					}
				}
			}
		}
	}, 400);
} 

function renderSbPopups() {
    
    if (isMobile) {
        ej.base.select('.sb-mobile-preference').appendChild(ej.base.select('.sb-setting-container'));
    }

    themeSwitherPopup = new ej.popups.Popup(document.getElementById('theme-switcher-popup'), {
        offsetX: 0,
        offsetY: 2,
        relateTo: document.querySelector('.theme-wrapper'),
        position: {
            X: 'left',
            Y: 'bottom'
        },
        collision: {
            X: 'flip',
            Y: 'flip'
        }
    });

    sdkSwitherPopup = new ej.popups.Popup(document.getElementById('sdk-switcher-popup'), {
        offsetX: 0,
        offsetY: 2,
        relateTo: document.querySelector('.sdk-wrapper'),
        position: {
            X: 'left',
            Y: 'bottom'
        },
        collision: {
            X: 'flip',
            Y: 'flip'
        }
    });
    
    cultureDropDown = document.getElementById("sb-setting-culture");
    cultureDropDown.value = localStorage.getItem('ej2-culture-name') || 'English';
    contentTab = document.getElementById('sb-content');
    sourceTab = document.getElementById('sb-source-tab');
}

function setCopyCode(){
    var ele = ej.base.createElement('div', { className: 'copy-tooltip', innerHTML: '<div class="e-icons copycode"></div>' });
    document.getElementById('copy-tootip-element').appendChild(ele);
    ele.addEventListener('click', copyCode);
}

function dynamicTabCreation(obj){
    var tabObj
    if (obj) {
        tabObj = obj;
    } else { tabObj = this; }
    var contentEle = tabObj.element.querySelector('#e-content' + tabObj.tabId + '_' + tabObj.selectedItem);
    if (!contentEle) {
        return;
    }
    var blockEle = tabObj.element.querySelector('#e-content' + tabObj.tabId + '_' + tabObj.selectedItem).children[0];
    blockEle.innerHTML = tabObj.items[tabObj.selectedItem].data;
    blockEle.innerHTML = blockEle.innerHTML.replace(reg, '');
    blockEle.classList.add('sb-src-code');
    blockEle.style.height = "500px";
    blockEle.style.overflowY = "auto";
    blockEle.setAttribute("tabindex", "0");
    if (blockEle) {
        hljs.highlightBlock(blockEle);
    }
}

function tabSelection(e) {
    if (e.selectedIndex == 1) {
        sourceTab.ej2_instances[0].items = ArrayItem;
        sourceTab.ej2_instances[0].refresh();
        dynamicTabCreation(sourceTab.ej2_instances[0]);
    }
}

function dataBound(args) {
    var gridtrs = this.getRows().length;
    var trs = this.getRows();
    for (var count = 0; count < gridtrs; count++) {
        var tr1 = trs[count];
        if (tr1.getBoundingClientRect().height > 100) {
            var desDiv = tr1.querySelector('.sb-sample-description');
            var tag = ej.base.createElement('a', { id: 'showtag', innerHTML: ' show more...' });
            tag.addEventListener('click', tagShowmore.bind(this, desDiv));
            if(desDiv != null){
                desDiv.classList.add('e-custDesription');
                desDiv.appendChild(tag);
            }  
        }
    }
}

function tagShowmore(target) {
    target.classList.remove('e-custDesription');
    target.querySelector('#showtag').classList.add('e-display');
    var hideEle = target.querySelector('#hidetag');
    if (!hideEle) {
        var tag = ej.base.createElement('a', { id: 'hidetag', attrs: {}, innerHTML: 'hide less..' });
        target.appendChild(tag);
        tag.addEventListener('click', taghideless.bind(this, target));
    } else {
        hideEle.classList.remove('e-display');
    }
}

function taghideless(target) {
    target.querySelector('#hidetag').classList.add('e-display');
    target.querySelector('#showtag').classList.remove('e-display');
    target.classList.add('e-custDesription');
}

function setPressedAttribute(ele) {
    var status = ele.classList.contains('active');
    ele.setAttribute('aria-pressed', status ? 'true' : 'false');
}

function sbHeaderClick(action, preventSearch) {
    if (openedPopup) {
        openedPopup.hide(new ej.base.Animation({ name: 'FadeOut', duration: 300, delay: 0 }));
    }
    if (preventSearch !== true && !searchOverlay.classList.contains('sb-hide')) {
        searchOverlay.classList.add('sb-hide');
        searchButton.classList.remove('active');
	searchEle.classList.remove('e-popup-open');
        searchEle.classList.add('e-popup-close');
        setPressedAttribute(searchButton);
    }
    var curPopup;
    switch (action) {
        case 'changeSampleBrowser':
            curPopup = switcherPopup;
            break;
        case 'changeTheme':
            if (leftToggle.classList.contains('toggle-active') && isTablet) {
                toggleLeftPane();
            }
            settingElement.classList.remove('active');
            headerThemeSwitch.classList.toggle('active');
            setPressedAttribute(headerThemeSwitch);
            curPopup = themeSwitherPopup;
            break;
        case 'changeSdk':
            if (leftToggle.classList.contains('toggle-active') && isTablet) {
                toggleLeftPane();
            }
            settingElement.classList.remove('active');
            headerSdkSwitch.classList.toggle('active');
            setPressedAttribute(headerSdkSwitch);
            curPopup = sdkSwitherPopup;
            break;
        case 'toggleSettings':
            if (leftToggle.classList.contains('toggle-active') && isTablet) {
                toggleLeftPane();
            }
            headerThemeSwitch.classList.remove('active');
            settingElement.classList.toggle('active');
            setPressedAttribute(settingElement);
            themeDropDown.index = themes.indexOf(selectedTheme);
            curPopup = settingsPopup;
            break;
    }
    if (action === 'closePopup') {
        headerThemeSwitch.classList.remove('active');
        headerSdkSwitch.classList.remove('active');
        settingElement.classList.remove('active');
    }
    if (curPopup && curPopup !== openedPopup) {
        curPopup.show(new ej.base.Animation({ name: 'FadeIn', duration: 400, delay: 0 }));
        openedPopup = curPopup;
    } else {
        openedPopup = null;
    }
    prevAction = action;
}

function toggleSearchOverlay() {
    sbHeaderClick('closePopup', true);
    inputele.value = '';
    searchPopup.hide();
    searchButton.classList.toggle('active');
    setPressedAttribute(searchButton);
    searchOverlay.classList.toggle('sb-hide');
    if (!searchOverlay.classList.contains('sb-hide')) {
        inputele.focus();
    }
}

function changeTheme(e) {
    var target = e.target;
    target = ej.base.closest(target, 'li');
    var themeName = target.id;
    if (!isStaging) { themeName = themeName === 'bootstrap5.3' ? 'bootstrap5' : themeName; }
    var storedURL = localStorage.getItem('PreviousURL');
    if (storedURL != null && storedURL.includes("-dark") && themeName != "bootstrap4" && themeName != "highcontrast" && themeName != "fluent2-highcontrast") {
        themeName = themeName + "-dark";
    } else {
        themeName = themeName;
    }
    switchTheme(themeName);
    var imageEditorElem = document.querySelector(".e-image-editor");
    if (imageEditorElem != null) {
        var imageEditor = ej.base.getComponent(document.getElementById(imageEditorElem.id), 'image-editor');
        imageEditor.theme = themeName;
    }
}

function handleSdkKeyboard(e) {
    var key = e.key;
    var target = e.target;
    var sdkList = document.getElementById('sdklist');
    if (!sdkList) { return; }
    // If the keydown didn't come from a list item, fall back to the active
    // item (or the first item) so the keyboard still works when focus is
    // on the SDK trigger button or anywhere outside the list.
    var currentItem = ej.base.closest(target, 'li');
    if (!currentItem || !sdkList.contains(currentItem)) {
        currentItem = sdkList.querySelector('li.active') || sdkList.querySelector('li');
    }
    if (!currentItem) { return; }

    // Get all visible list items
    var allItems = sdkList.querySelectorAll('li');
    var visibleItems = [];
    for (var i = 0; i < allItems.length; i++) {
        // Include all items that are not hidden child items of collapsed groups
        var item = allItems[i];
        var parentGroup = item.getAttribute('data-sdk-group');

        // If item is a child, check if parent group is expanded
        if (parentGroup) {
            var parent = document.getElementById(parentGroup);
            if (parent && parent.getAttribute('aria-expanded') === 'false') {
                continue; // Skip hidden children
            }
        }
        visibleItems.push(item);
    }

    var currentIndex = -1;
    for (var j = 0; j < visibleItems.length; j++) {
        if (visibleItems[j] === currentItem) {
            currentIndex = j;
            break;
        }
    }

    var nextItem = null;

    switch(key) {
        case 'ArrowDown':
            if (currentIndex >= 0 && currentIndex < visibleItems.length - 1) {
                nextItem = visibleItems[currentIndex + 1];
            } else if (currentIndex === -1 && visibleItems.length > 0) {
                nextItem = visibleItems[0];
            }
            e.preventDefault();
            break;

        case 'ArrowUp':
            if (currentIndex > 0) {
                nextItem = visibleItems[currentIndex - 1];
            } else if (currentIndex === -1 && visibleItems.length > 0) {
                nextItem = visibleItems[0];
            }
            e.preventDefault();
            break;

        case 'Enter':
        // case ' ':
            // Trigger click on the current item
            var clickEvent = new MouseEvent('click', {
                bubbles: true,
                cancelable: true,
                view: window
            });
            currentItem.dispatchEvent(clickEvent);
            e.preventDefault();
            break;

        case 'Escape':
            // Close the popup if it's open
            if (sdkSwitherPopup) {
                sdkSwitherPopup.hide();
            }
            e.preventDefault();
            break;
    }

    // Move focus to the next item
    if (nextItem && typeof nextItem.focus === 'function') {
        nextItem.focus();
    }
}

function changeSdk(e) {
    var target = e.target;
    target = ej.base.closest(target, 'li');
    if (!target) { return; }
    var sdkName = target.id;
    // The 'StandaloneGroup' li is the group header for the standalone SDKs.
    // Clicking it should toggle the group's expand/collapse state, NOT change
    // the active SDK or navigate. The actual toggle handler is wired in
    // getSdkSwitcher() so the click is handled there before this generic
    // handler runs. As a safety net we just stop propagation here.
    if (sdkName === 'StandaloneGroup') {
        e.stopPropagation();
        e.preventDefault();
        return;
    }
    // The 'DocumentSolutionsGroup' li is the group header for the
    // Document Solutions children. Clicking it toggles the group's
    // expand/collapse state, exactly like StandaloneGroup.
    if (sdkName === 'DocumentSolutionsGroup') {
        e.stopPropagation();
        e.preventDefault();
        var docGroup = document.getElementById('DocumentSolutionsGroup');
        if (docGroup) {
            var isExpanded = docGroup.getAttribute('aria-expanded') === 'true';
            docGroup.setAttribute('aria-expanded', isExpanded ? 'false' : 'true');
        }
        return;
    }
    // The four Document Solutions children (DocumentSDK, PdfViewerSDK,
    // DocxEditorSDK, SpreadsheetEditorSDK) all carry data-no-active="true"
    // and are not part of the active SDK. Clicking one opens the
    // corresponding Document Solutions demo in a new browser tab. They
    // must not be marked as the active SDK, must not change the URL or
    // sdk query param, and must not navigate to a default sample path.
    if (target.getAttribute('data-no-active') === 'true') {
        e.stopPropagation();
        e.preventDefault();
        var docSolutionUrls = {
            'DocumentSDK': 'https://document.syncfusion.com/#/document-sdk',
            'PdfViewerSDK': 'https://document.syncfusion.com/demos/pdf-viewer/asp-net-core/pdfviewer/default#/tailwind3',
            'DocxEditorSDK': 'https://document.syncfusion.com/demos/docx-editor/asp-net-core/documenteditor/default',
            'SpreadsheetEditorSDK': 'https://document.syncfusion.com/demos/spreadsheet-editor/asp-net-core/spreadsheet/defaultfunctionalities'
        };
        var targetUrl = docSolutionUrls[sdkName];
        if (targetUrl) {
            window.open(targetUrl, '_blank', 'noopener,noreferrer');
        }
        return;
    }
    // Mark active state
    var sdkList = document.getElementById('sdklist');
    if (sdkList) {
        var items = sdkList.querySelectorAll('li');
        for (var i = 0; i < items.length; i++) {
            // Don't clear the active state of the StandaloneGroup parent
            // (it's not a selectable item but a group header).
            if (items[i].id !== 'StandaloneGroup') {
                items[i].classList.remove('active');
            }
        }
        target.classList.add('active');
        // Update the SDK switcher trigger text to reflect the active SDK.
        var labelSpan = target.querySelector('.switch-text');
        var activeText = document.querySelector('#header-sdk-switcher .sb-sdk-active-text');
        if (labelSpan && activeText) {
            activeText.textContent = labelSpan.textContent.trim();
        }
        // Also update the mobile secondary header SDK switcher label.
        var mobileActiveText = document.querySelector('#header-sdk-switcher-mobile .sb-sdk-active-text');
        if (labelSpan && mobileActiveText) {
            mobileActiveText.textContent = labelSpan.textContent.trim();
        }
        // Auto-expand the Standalone group when a child is selected, so the user
        // can see the active child after the page reloads.
        var group = document.getElementById('StandaloneGroup');
        if (group) {
            var standaloneChildIds = ['Grid', 'Charts', 'Scheduler', 'Gantt', 'RichTextEditor', 'Diagram', 'FileManager'];
            if (standaloneChildIds.indexOf(sdkName) !== -1) {
                group.setAttribute('aria-expanded', 'true');
            } else {
                group.setAttribute('aria-expanded', 'false');
            }
        }
    }
    // Get the current theme from the URL hash
    var currentTheme = (location.hash.split('/')[1]) || defaultTheme;
    // 'UIEdition' is a special case: navigate to the default grid sample WITHOUT
    // any sdk query param in the URL.
    if (sdkName === 'UIEdition') {
        var defaultPath = getDefaultSampleForSdk('UIEdition') || 'grid/gridoverview';
        var basePath = location.pathname.split('/').slice(0, -2).join('/');
        var newUrl = location.origin + basePath + '/' + defaultPath + '#/' + currentTheme;
        window.location.href = newUrl;
        return;
    }
    // Build the new URL. Always include the sdk query param (lowercase).
    var defaultPath = getDefaultSampleForSdk(sdkName);
    if (defaultPath) {
        var basePath = location.pathname.split('/').slice(0, -2).join('/');
        var queryString = '?sdk=' + encodeURIComponent(sdkName.toLowerCase());
        var newUrl = location.origin + basePath + '/' + defaultPath + queryString + '#/' + currentTheme;
        window.location.href = newUrl;
    } else {
        // Fallback: just update query param
        var url = new URL(window.location.href);
        url.searchParams.set('sdk', sdkName.toLowerCase());
        window.location.href = url.toString();
    }
}

// Returns the default control/sample path for a given SDK id (e.g. 'Charts' -> 'chart/overview')
// Case-insensitive: accepts both 'Grid' and 'grid' as input.
// Paths are lowercase because the routing in addRoutes() lowercases the directory and url.
function getDefaultSampleForSdk(sdkId) {
    var mapping = {
        'UIEdition': 'grid/gridoverview',
        'Grid': 'grid/gridoverview',
        'Charts': 'chart/overview',
        'Diagram': 'diagram/flowchart',
        'Gantt': 'gantt/overview',
        'FileManager': 'filemanager/overview',
        'Scheduler': 'schedule/overview',
        'RichTextEditor': 'richtexteditor/overview'
    };
    if (mapping[sdkId]) {
        return mapping[sdkId];
    }
    // Try matching in a case-insensitive way
    var lower = (sdkId || '').toLowerCase();
    for (var key in mapping) {
        if (key.toLowerCase() === lower) {
            return mapping[key];
        }
    }
    return null;
}

function mapSdkIdToDisplayName(sdkId) {
    var mapping = {
        'Grid': 'Grid SDK',
        'Charts': 'Chart SDK',
        'Diagram': 'Diagram SDK',
        'Gantt': 'Gantt SDK',
        'FileManager': 'FileManager SDK',
        'Scheduler': 'Scheduler SDK',
        'RichTextEditor': 'RTE SDK'
    };
    if (mapping[sdkId]) {
        return mapping[sdkId];
    }
    // Try matching in a case-insensitive way (so 'grid' from query string also works)
    var lower = (sdkId || '').toLowerCase();
    for (var key in mapping) {
        if (key.toLowerCase() === lower) {
            return mapping[key];
        }
    }
    return null;
}

// Returns a dictionary (directory -> true) of all components that match the current SDK
// resolved from the URL query parameter. Returns null when the SDK cannot be determined,
// indicating that the search results should not be filtered.
function getAllowedDirectoriesForCurrentSdk() {
    var knownIds = ['Grid', 'Charts', 'Diagram', 'Gantt', 'FileManager', 'Scheduler', 'RichTextEditor'];
    var urlParams = new URLSearchParams(window.location.search);
    var rawSdk = urlParams.get('sdk');
    var resolvedSdk = null;
    if (rawSdk) {
        for (var k = 0; k < knownIds.length; k++) {
            if (knownIds[k].toLowerCase() === rawSdk.toLowerCase()) {
                resolvedSdk = knownIds[k];
                break;
            }
        }
    }
    if (!resolvedSdk) {
        return null; // No filter; show everything.
    }
    var sdkDisplayName = mapSdkIdToDisplayName(resolvedSdk);
    if (!sdkDisplayName) {
        return null;
    }
    var allowed = {};
    var all = (window.samplesList || []);
    for (var i = 0; i < all.length; i++) {
        var comp = all[i];
        if (comp && comp.Sdk && comp.Sdk.indexOf(sdkDisplayName) !== -1 && comp.directory) {
            allowed[comp.directory.toLowerCase()] = true;
        }
    }
    return allowed;
}

function filterSamplesBySdk(list, sdkName) {
    var filtered = [];
    for (var i = 0; i < list.length; i++) {
        var component = list[i];
        if (component && component.Sdk && component.Sdk.indexOf(sdkName) !== -1) {
            filtered.push(component);
        }
    }
    return filtered;
}

function switchTheme(str) {
    if (typeof str === 'string') {
        var themeName = str;
    } else {
        if (str.value) {
            var dropdownMode = document.getElementById("sb-setting-mode").ej2_instances[0];
            if (window.matchMedia("(max-width: 550px)").matches) {
                if (str.value != "bootstrap4" && str.value != "highcontrast" && str.value != "fluent2-highcontrast") {
                    if (dropdownMode.itemData.ThemeId == "dark") {
                        // Set the value of the second dropdown to "dark"
                        dropdownMode.value = "dark";
                        themeName = str.value + "-dark";
                    }
                    else {
                        // Set the value of the second dropdown to "light"
                        dropdownMode.value = "light";
                        themeName = str.value;
                    }
                }
                else {
                    dropdownMode.value = dropdownMode.itemData.ThemeId;
                    themeName = str.value;
                }
            }
            else {
                // Set the value of the second dropdown to "light"
                dropdownMode.value = "light";
                themeName = str.value;
            }
            // localStorage.setItem('dropdownlistsb-setting-mode', str.itemData.Index);
        }
    }
    var hash = location.hash.split('/');
    if (!isStaging) { themeName = themeName === 'bootstrap5.3' ? 'bootstrap5' : themeName === 'bootstrap5.3-dark' ? 'bootstrap5-dark' : themeName; }
    if (hash[1] !== themeName) {
        hash[1] = themeName;
        localStorage.setItem('ej2-switch', ej.base.select('.sb-responsive-section .active').id);
        // localStorage.setItem('dropdownlistsb-setting-mode', themeIndex[str]);
        location.hash = hash.join('/');
        location.reload();
    }
}

function onsearchInputChange(e) {
    if (e.keyCode === 27) {
        toggleSearchOverlay();
    }
    var searchString = e.target.value;
    if (searchString.length <= 2) {
        searchPopup.hide();
        return;
    }
    var val = [];
    val = searchInstance.search(searchString, {
        fields: {
            component: { boost: 1 },
            name: { boost: 2 }
        },
        expand: true,
        boolean: 'AND'
    });
    // Build a set of directories that belong to the currently selected SDK so the
    // search results are filtered to components within the active SDK.
    var allowedDirs = getAllowedDirectoriesForCurrentSdk();
    if (allowedDirs) {
        var filtered = [];
        for (var f = 0; f < val.length; f++) {
            var docDir = (val[f].doc && val[f].doc.dir) ? val[f].doc.dir.toLowerCase() : '';
            if (docDir && allowedDirs[docDir]) {
                filtered.push(val[f]);
            }
        }
        val = filtered;
    }
    var value = [];
    if (ej.base.Browser.isDevice) {
        for (var j = 0; j < val.length; j++) {
            if (val[j].doc.hideOnDevice !== true) {
                value = value.concat(val);
            }
        }
    }
    var searchVal = ej.base.Browser.isDevice ? value : val;
   
    if (searchVal.length) {
        var data = new ej.data.DataManager(searchVal);

        var controls = data.executeLocal(new ej.data.Query().take(10).select('doc'));
        var controlsAccess = [];
        for (var i = 0, controls = controls; i < controls.length; i++) {
            var cont = controls[i];
            controlsAccess.push(cont.doc);
        }
        controls = controlsAccess;
        var count = 1;
        var controlCollection = {};
        controlCollection[controls[0].component] = count;
        controls[0].sortId = count;
        for (var i = 1; i < controls.length; i++) {
            var curComponent = controls[i].component;
            var previd = controlCollection[curComponent];
            if (previd) {
                controls[i].sortId = previd;
            } else {
                ++count;
                controlCollection[curComponent] = count;
                controls[i].sortId = count;
            }
        }
        searchListView.dataSource = controls;
        document.getElementById('search-no-records').style.display = 'none';
        document.getElementById('search-result-list').style.display = 'block';
        searchPopup.show();
    } else {
        document.getElementById('search-result-list').style.display = 'none';
        searchPopup.element.classList.add('search-no-record');
        searchPopup.show();
        document.getElementById('search-no-records').style.display = 'block';
    }
}

function highlight(searchString, listElement) {
    var regex = new RegExp(searchString.split(' ').join('|'), 'gi');
    var contentElements = ej.base.selectAll('.e-list-item .e-text-content .e-list-text', listElement);
    for (var i = 0; i < contentElements.length; i++) {
        var spanText = ej.base.select('.sb-highlight', contentElements[i]);
        if (spanText) {
            contentElements[i].innerHTML = contentElements[i].text;
        }
        contentElements[i].innerHTML = contentElements[i].innerHTML.replace(regex, function (matched) {
            return '<span class="sb-highlight">' + matched + '</span>';
        });
    }
}

function setMouseOrTouch(e) {
    var ele = ej.base.closest(e.target, '.sb-responsive-items');
    var switchType = ele.id;
    var modeType = document.body.classList.contains("e-bigger")?"touch":"mouse";
    changeMouseOrTouch(switchType);
    sbHeaderClick('closePopup');
    localStorage.setItem('ej2-switch', switchType);
    if(!(switchType == modeType))
    {
        location.reload();
    }
}

function onNextPrevButtonClick(arg) {
    sampleOverlay();
    var theme = getThemeName();
    var curSampleUrl = getSamplePath();
    var inx = samplesAr.indexOf(curSampleUrl);
    if (inx !== -1) {
        var prevhref = samplesAr[inx];
        var curhref = (this.id === 'next-sample' || this.id === 'mobile-next-sample') ? samplesAr[inx + 1] : samplesAr[inx - 1];
        location.href = location.origin + getPathName() + curhref + getSdkQueryString() + '#/' + theme;
    }
    window.hashString = location.origin + getPathName() + curhref + getSdkQueryString() + '#/' + theme;
    setSelectList();
}

function processResize(e) {
    isMobile = window.matchMedia('(max-width:550px)').matches;
    if (resizeManualTrigger || (isMobile && !ej.base.select('.sb-mobile-right-pane').classList.contains('sb-hide'))) {
        return;
    }
    isTablet = window.matchMedia('(min-width:550px) and (max-width: 850px)').matches;
    isPc = window.matchMedia('(min-width:850px)').matches;
    processDeviceDependables();
    setLeftPaneHeight();
    var leftPane = ej.base.select('.sb-left-pane');
    var rightPane = ej.base.select('.sb-right-pane');
    var footer = ej.base.select('.sb-footer-left');
    var pref = ej.base.select('#settings-popup');
    if (isMobile) {
        leftPane.classList.remove('sb-hide');
        if (leftPane.parentElement.classList.contains('sb-mobile-left-pane')) {
            if (!leftPane.parentElement.classList.contains('sb-hide')) {
                toggleLeftPane();
            }
        } else {
            ej.base.select('.sb-mobile-left-pane').appendChild(leftPane);
            ej.base.select('.sb-left-footer-links').appendChild(footer);
            if (!ej.base.select('.sb-mobile-left-pane').classList.contains('sb-hide')) {
                toggleLeftPane();
            } else {
                leftToggle.classList.remove('toggle-active');
            }
            if (isVisible('.sb-mobile-overlay')) {
                removeMobileOverlay();
            }
        }
        if (!pref.parentElement.classList.contains('sb-mobile-preference')) {
            ej.base.select('.sb-mobile-preference').appendChild(pref);
            settingsPopup.show();
        }
        var propPanel = ej.base.select('#control-content .property-section');
        if (propPanel) {
            propPanel.classList.remove('panel-hidden');
            propPanel.style.removeProperty('width');
            var mobileSetting = ej.base.select('.sb-mobile-setting');
            if (mobileSetting) {
                mobileSetting.classList.add('sb-hide');
            }
        }
        if (isVisible('.sb-mobile-overlay')) {
            removeMobileOverlay();
        }
    }
    if (isTablet || isPc) {
        if (leftPane.parentElement.classList.contains('sb-mobile-left-pane')) {
            ej.base.select('.sb-content').appendChild(leftPane);
            ej.base.select('.sb-footer').appendChild(footer);
            if (isVisible('.sb-mobile-overlay')) {
                removeMobileOverlay();
            }
        }
        if (isTablet || (ej.base.Browser.isDevice && isPc)) {
            if (!leftPane.classList.contains('sb-hide')) {
                toggleLeftPane();
            }
            setTimeout(function () {
                if (!rightPane.classList.contains('control-fullview')) {
                    rightPane.classList.add('control-fullview');
                }
            }, 600);
        }
        if (isPc && !ej.base.Browser.isDevice && isVisible('.sb-left-pane')) {
            rightPane.classList.remove('control-fullview');
        }
        if (pref.parentElement.classList.contains('sb-mobile-preference')) {
            ej.base.select('#sb-popup-section').appendChild(pref);
            settingsPopup.hide();
        }
        var propPanel = ej.base.select('#control-content .property-section');
        var isLandscapeTablet = window.matchMedia('max-width: 1024px').matches;
        if (isTablet || isLandscapeTablet) {
            propPanel.classList.remove('panel-hidden');
            propPanel.style.removeProperty('width');
            var mobileSettingTablet = ej.base.select('.sb-mobile-setting');
            if (mobileSettingTablet) {
                mobileSettingTablet.classList.add('sb-hide');
            }
        }
        if (!ej.base.select('.sb-mobile-right-pane').classList.contains('sb-hide')) {
            toggleRightPane();
        }
    }
}

function resetInput(arg) {
    arg.preventDefault();
    arg.stopPropagation();
    document.getElementById('search-input').value = '';
    document.getElementById('search-input-wrapper').setAttribute('data-value', '');
    searchPopup.hide();
}

function bindEvents() {
    document.getElementById('sb-switcher').addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        sbHeaderClick('changeSampleBrowser');
    });
    ej.base.select('.sb-header-text-right').addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        sbHeaderClick('changeSampleBrowser');
    });
    headerThemeSwitch.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        sbHeaderClick('changeTheme');
    });
    themeList.addEventListener('click', changeTheme);
    headerSdkSwitch.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        sbHeaderClick('changeSdk');
    });
    // Wire the mobile-only secondary SDK switcher (lives in its own header bar).
    var headerSdkSwitchMobile = document.getElementById('header-sdk-switcher-mobile');
    if (headerSdkSwitchMobile) {
        headerSdkSwitchMobile.addEventListener('click', function (e) {
            e.preventDefault();
            e.stopPropagation();
            sbHeaderClick('changeSdk');
        });
    }
    var sdkList = document.getElementById('sdklist');
    if (sdkList) {
        sdkList.addEventListener('click', changeSdk);
    }
    document.addEventListener('click', sbHeaderClick.bind(this, 'closePopup'));
    notificationElement.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        toggleNotification();
    });
    settingElement.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        sbHeaderClick('toggleSettings');
    });
    searchButton.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
        toggleSearchOverlay();
    });
    document.getElementById('settings-popup').addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
    });
    inputele.addEventListener('click', function (e) {
        e.preventDefault();
        e.stopPropagation();
    });
    inputele.addEventListener('keyup', onsearchInputChange);
    setResponsiveElement.addEventListener('click', setMouseOrTouch);
    ej.base.select('#sb-left-back').addEventListener('click', showHideControlTree);
    leftToggle.addEventListener('click', toggleLeftPane);
    ej.base.select('.sb-mobile-overlay').addEventListener('click', toggleMobileOverlay);
    ej.base.select('.sb-header-settings').addEventListener('click', viewMobilePrefPane);
    ej.base.select('.sb-mobile-setting').addEventListener('click', viewMobilePropPane);
    resetSearch.addEventListener('click', resetInput);
    ej.base.select('#next-sample').addEventListener('click', onNextPrevButtonClick);
    ej.base.select('#mobile-next-sample').addEventListener('click', onNextPrevButtonClick);
    ej.base.select('#prev-sample').addEventListener('click', onNextPrevButtonClick);
    ej.base.select('#mobile-prev-sample').addEventListener('click', onNextPrevButtonClick);
    window.addEventListener('resize', processResize);
    ej.base.select('.sb-right-pane').addEventListener('click', function () {
        if (isTablet && isLeftPaneOpen()) {
            toggleLeftPane();
        }
    });
    searchEle.addEventListener('click', function (e) {
        var curEle = ej.base.closest(e.target, 'li');
        if (curEle && curEle.classList.contains('e-list-item')) {
            var tcontent = curEle.querySelector('.e-text-content');
            var hashval = '#/' + selectedTheme + '/' + tcontent.getAttribute('data') + '.html';
            inputele.value = '';
            searchPopup.hide();
            searchOverlay.classList.add('e-search-hidden');
            if (location.hash !== hashval) {
                sampleOverlay();
                setSelectList();
            }
        }
    });
}

function copyCode() {
    var copyElem = ej.base.select('#sb-source-tab .e-item.e-active');
    var textArea = ej.base.createElement('textArea');
    textArea.textContent = copyElem.textContent.trim();
    document.body.appendChild(textArea);
    textArea.select();
    document.execCommand('copy');
    ej.base.detach(textArea);
}

function setSbLink() {
    var href = location.href;
    var link = href.match(urlRegex);
    var sample = href.match(sampleRegex);
    for (var i = 0, len = sbArray.length; i < len; i++) {
        var sb = sbArray[i];
        var ele = ej.base.select('#' + sb);
        if (sb === 'aspnetmvc') {
            ele.href = 'http://ej2.syncfusion.com/aspnetmvc/';
        } else {
            ele.href = ((link) ? ('http://' + link[1] + '/' + (link[3] ? (link[3] + '/') : '')) :
                ('http://ej2.syncfusion.com/')) + (sbObj[sb] ? (sb + '/') : '') + ((sb === 'blazor') ? 'demos/' :
                'demos/#/') + (sample ? (sample[1] + (sb !== 'typescript' ? '' : '.html')) : '');
        }
    }
}

function changeMouseOrTouch(str) {
    var activeEle = setResponsiveElement.querySelector('.active');
    if (activeEle) {
        activeEle.classList.remove('active');
    }
    if (str === 'mouse') {
        document.body.classList.remove('e-bigger');
    } else {
        document.body.classList.add('e-bigger');
    }
    setResponsiveElement.querySelector('#' + str).classList.add('active');
}

// check the current themevalue present in themelist based on condition add active class
function addActiveThemePresent(themeList, themeId) {
    const el = themeList?.querySelector(`[id="${themeId}"]`);
    if (el){
 		el.classList.add('active');
	}
}


function loadTheme(theme) {
    var body = document.body;
    if (body.classList.length > 0) {
        for (var themeItem in themes) {
            body.classList.remove(themes[themeItem]);
        }
    }
    if (!isStaging) {
        theme = theme == 'bootstrap5' ? 'bootstrap5.3' : theme == 'bootstrap5-dark' ? 'bootstrap5.3-dark' : theme;
    }

    body.classList.add(theme);
    themeList.querySelector('.active').classList.remove('active');
   
    var currentUpdatedTheme = theme.replace("-dark", "");
    addActiveThemePresent(themeList, currentUpdatedTheme);
    selectedTheme = theme;
    renderLeftPaneComponents();
    renderSbPopups();
    bindEvents();
    processDeviceDependables();
    sampleArray();
    addRoutes(samplesList);
    if (isTablet && isLeftPaneOpen()) {
        toggleLeftPane();
    }
    elasticlunr.clearStopWords();
    const script = document.createElement('script');
    const jsSuffix = isStaging ? ".min" : "";
    script.src = window.baseurl + 'Scripts/search-index'+jsSuffix +'.js';
    script.type = 'text/javascript';
    script.onload = function () {
        searchInstance = elasticlunr.Index.load(window.searchIndex);
    }
    document.head.appendChild(script);
    hasher.initialized.add(parseHash);
    hasher.changed.add(parseHash);
    hasher.init();
   /* removing dark or light them options for fluent2-highcontrast themeSwitchDiv*/
    if (theme == 'fluent2-highcontrast' || theme == 'bootstrap4') {
        var theamswitchDivDisable = document.getElementById("themeSwitchDiv");
        theamswitchDivDisable.style.display = 'none';
    }

    var mobileThemeModeElement = document.getElementById('themeSwitchMobile');
    var mobileThemeModeDropDownstyle = window.getComputedStyle(mobileThemeModeElement);
    if (mobileThemeModeDropDownstyle.display === "block") {
        var hashValue = window.location.href.split("#/")[1];
        if (hashValue !== 'fluent2-highcontrast' && hashValue !== 'highcontrast' && hashValue !== 'bootstrap4') {
            if (hashValue === undefined) {
                hashValue = '';
            }
            if (hashValue.includes('-dark')) {
                localStorage.setItem('dropdownlistsb-setting-mode', '{"value":"dark"}');
            }
            else {
                localStorage.setItem('dropdownlistsb-setting-mode', '{"value":"light"}');
            }
        }
    }
}

function toggleMobileOverlay() {
    if (!ej.base.select('.sb-mobile-left-pane').classList.contains('sb-hide')) {
        toggleLeftPane();
    }
    if (!ej.base.select('.sb-mobile-right-pane').classList.contains('sb-hide')) {
        toggleRightPane();
    }
}

function removeMobileOverlay() {
    ej.base.select('.sb-mobile-overlay').classList.add('sb-hide');
}

function isLeftPaneOpen() {
    return leftToggle.classList.contains('toggle-active');
}

function isVisible(elem) {
    return !ej.base.select(elem).classList.contains('sb-hide');
}

function setLeftPaneHeight() {
    var leftPane = ej.base.select('.sb-left-pane');
    leftPane.style.height = isMobile ? ('100%') : '';
}

function toggleLeftPane() {
    var toggleAnim = new ej.base.Animation({ duration: 500, timingFunction: 'ease' });
    var leftPane = ej.base.select('.sb-left-pane');
    var rightPane = ej.base.select('.sb-right-pane');
    var mobileLeftPane = ej.base.select('.sb-mobile-left-pane');
    var reverse = leftPane.classList.contains('sb-hide');
    if (reverse) {
        leftToggle.classList.add('toggle-active');
    } else {
        leftToggle.classList.remove('toggle-active');
    }
    if (!isMobile) {
        leftPane.classList.remove('sb-hide');
        rightPane.classList.add('control-transition');
        rightPane.style.overflowY = 'hidden';
        if (!reverse) {
            rightPane.classList.add('control-animate');
        } else {
            rightPane.classList.add('control-reverse-animate');
        }
    } else {
        reverse = mobileLeftPane.classList.contains('sb-hide');
        mobileLeftPane.classList.remove('sb-hide');
    }
    ej.base.select('.sb-mobile-overlay').classList.toggle('sb-hide');
    if (!reverse) {
        rightPane.classList.remove('control-fullview');
    } else {
        rightPane.classList.add('control-fullview');
    }
    toggleAnim.animate(leftPane, {
        name: reverse ? 'SlideLeftIn' : 'SlideLeftOut',
        end: function () {
            if (!isMobile) {
                rightPane.classList.remove('control-transition');
                rightPane.style.overflowY = 'auto';
                if (!reverse) {
                    leftPane.classList.add('sb-hide');
                    rightPane.classList.remove('control-animate');
                } else {
                    rightPane.classList.remove('control-reverse-animate');
                }
                rightPane.classList.toggle('control-fullview');
            } else if (isMobile && !reverse) {
                mobileLeftPane.classList.add('sb-hide');
            }
            resizeManualTrigger = true;
            window.dispatchEvent(new Event('resize'));
            if (ej.base.Browser.isDevice) {
                window.dispatchEvent(new Event('orientationchange'));
            }
            resizeManualTrigger = false;
        }
    });
}

function toggleRightPane() {
    var toggleAnim = new ej.base.Animation({ duration: 500, timingFunction: 'ease' });
    if(themeDropDown) { themeDropDown.index = themes.indexOf(selectedTheme); }
    var mRightPane = ej.base.select('.sb-mobile-right-pane');
    ej.base.select('.sb-mobile-overlay').classList.toggle('sb-hide');
    var reverse = mRightPane.classList.contains('sb-hide');
    mRightPane.classList.remove('sb-hide');
    toggleAnim.animate(mRightPane, {
        name: reverse ? 'SlideRightIn' : 'SlideRightOut',
        end: function () {
            if (!reverse) {
                mRightPane.classList.add('sb-hide');
            }
        }
    });
}

function viewMobilePrefPane() {
    ej.base.select('.sb-mobile-prop-pane').classList.add('sb-hide');
    ej.base.select('.sb-mobile-preference').classList.remove('sb-hide');
    document.querySelector('.sb-mobile-right-pane').style.height = '100%';
    toggleRightPane();
}

function viewMobilePropPane() {
    ej.base.select('.sb-mobile-preference').classList.add('sb-hide');
    ej.base.select('.sb-mobile-prop-pane').classList.remove('sb-hide');
    document.querySelector('.sb-mobile-right-pane').style.height = 'fit-content';
    toggleRightPane();
}

function getSampleList() {
    var resultList = window.samplesList;
    if (ej.base.Browser.isDevice) {
        var tempList = ej.base.extend([], window.samplesList);
        var sampleList = [];
        for (var i = 0; i < tempList.length; i++) {
            var temp = tempList[i];
            var data = new ej.data.DataManager(temp.samples);
            temp.samples = data.executeLocal(new ej.data.Query().where('hideOnDevice', 'notEqual', true));
            sampleList = sampleList.concat(temp);
        }
        resultList = sampleList;
    }
    // Store the full unfiltered list for later use
    window._fullSamplesList = resultList;
    // Apply SDK filter on initial load. URL query string is the single source of truth.
    // If the URL has no sdk param (i.e. UI Edition is selected), no filter is applied.
    var knownIds = ['Grid', 'Charts', 'Diagram', 'Gantt', 'FileManager', 'Scheduler', 'RichTextEditor'];
    var urlParams = new URLSearchParams(window.location.search);
    var rawSdk = urlParams.get('sdk');
    var resolvedSdk = null;
    if (rawSdk) {
        for (var k = 0; k < knownIds.length; k++) {
            if (knownIds[k].toLowerCase() === rawSdk.toLowerCase()) {
                resolvedSdk = knownIds[k];
                break;
            }
        }
    }
    // Only apply the SDK filter when a valid sdk query param is present in the URL.
    // If the sdk param is missing, return the unfiltered list so the actual sample loads.
    if (resolvedSdk && typeof mapSdkIdToDisplayName === 'function' && typeof filterSamplesBySdk === 'function') {
        var sdkDisplayName = mapSdkIdToDisplayName(resolvedSdk);
        if (sdkDisplayName) {
            resultList = filterSamplesBySdk(resultList, sdkDisplayName);
        }
    }
    return resultList;
}

function initializeAllControlSampleData() {
    // Populate controlSampleData from the full unfiltered list
    // This is called after page initialization to avoid blocking page load
    var fullList = window._fullSamplesList || window.samplesList;
    for (var i = 0; i < fullList.length; i++) {
        var component = fullList[i];
        if (component && component.samples) {
            var dirKey = component.directory.toLowerCase();
            if (!controlSampleData[dirKey]) {
                controlSampleData[dirKey] = getSamples(component.samples);
            }
        }
    }
}


function renderLeftPaneComponents() {
    samplesTreeList = getTreeviewList(samplesList);
}

function getTreeviewList(list) {
    var id;
    var pid;
    var tempList = [];
    var category = '';
    for (var i = 0; i < list.length; i++) {
        if (category !== list[i].category) {
            category = list[i].category;
            tempList = tempList.concat({ id: i + 1, name: list[i].category, hasChild: true, expanded: true });
            pid = i + 1;
            id = pid;
        }
        id += 1;
        tempList = tempList.concat({
            id: id,
            pid: pid,
            name: list[i].name,
            type: list[i].type,
            url: {
                'data-path': list[i].samples[0] ? list[i].directory.toLowerCase() + '/' + list[i].samples[0].url.toLowerCase() : "",
                'control-name': list[i].directory.toLowerCase(),
            }
        });
        // Only populate controlSampleData if it doesn't already exist (to preserve the full unfiltered list)
        var dirKey = list[i].directory.toLowerCase();
        if (!controlSampleData[dirKey]) {
            controlSampleData[dirKey] = getSamples(list[i].samples);
        }
    }
    return tempList;
}

function getSamples(samples) {
    var tempSamples = [];
    for (var i = 0; i < samples.length; i++) {
        tempSamples[i] = samples[i];
        tempSamples[i].data = { 'sample-name': samples[i].url.toLowerCase(), 'data-path': samples[i].dir.toLowerCase() + '/' + samples[i].url.toLowerCase() };
    }
    return tempSamples;
}

function getThemeName() {
    var themeName = defaultTheme;
    if (location.hash.split('/')[1] != null) {
        if (!isStaging) {
            themeName = location.hash.split('/')[1] === 'bootstrap5.3' ? 'bootstrap5' : location.hash.split('/')[1];
        }
        else {
            themeName = location.hash.split('/')[1];
        }
    }
    return themeName;
}

function getPathName() {
    var samplePath = getSamplePath();
    return location.pathname.replace(samplePath, '');
}

function getSamplePath() {
    return location.pathname.split('/').slice(-2).join('/');
}

// Returns the SDK query string portion of the URL (e.g. '?sdk=Grid') or empty string if not present
function getSdkQueryString() {
    return location.search && location.search.indexOf('sdk=') !== -1 ? location.search : '';
}
function searchNavigation(arg) {
    var eventType = arg.event ? arg.event.pointerType : null; 
    if (eventType){
        controlSelect(arg);
    }
}

function controlSelect(arg) {
    var path = (arg.node || arg.item).getAttribute('data-path');
    if (path === null && arg.data) {
        path = arg.data.dir.toLowerCase() + '/' + arg.data.url.toLowerCase();
    }
    var curHashCollection = '/' + location.href.split('/').slice(3).join('/');
    var theme = getThemeName();
    if (!arg.item || path.split('/')[1] === curHashCollection.split('/').slice(-2)[1]) {
        controlListRefresh(arg.node || arg.item);
    }
    if (location.pathname.slice(- 1) !== '/' && location.hash !== '#/' + theme) {
        var count; 
        if ((location.origin.indexOf('ej2npmci.azurewebsites') !== -1) && location.pathname.split('/').length >= 6) {
            count = 6;
        }
        else if ((location.origin.indexOf('ej2.syncfusion') !== -1) && location.pathname.split('/').length >= 5) {
            count = 5; 
        }
        else if ((location.origin.indexOf('localhost') !== -1) && location.pathname.split('/').length >= 3) {
            count = 3;
        }
        location.href = location.origin + location.pathname.split('/').slice(0, count).join('/') + getSdkQueryString() + '#/' + theme;
    }
    else {
        if (location.pathname.slice(- 1) === '/') {
            location.href = location.origin + curHashCollection.slice(0, -1) + getSdkQueryString() + '#/' + theme;
        }
        else if (path) {
            if (curHashCollection.replace(/^\//, '').split("#")[0] !== path) {
                sampleOverlay();
                if (arg.item && ((isMobile && !ej.base.select('.sb-mobile-left-pane').classList.contains('sb-hide')) ||
                    ((isTablet || (ej.base.Browser.isDevice && isPc)) && isLeftPaneOpen()))) {
                    toggleLeftPane();
                }

                if (arg.data) {
                    var pathName = location.pathname.replace(getSamplePath(), '');
                    if (curHashCollection.split('/')[curHashCollection.split('/').length - 3] != arg.data.dir.toLowerCase()) {
                        var SampleObject = window.samplesList.filter(obj => obj.directory.toLowerCase() === arg.data.dir.toLowerCase());
                        var defaultSample = SampleObject.map(obj => obj.samples[0]);
                        //URL update while we navigate through search
                        if (arg.item.id.includes("search-result-list")) {
                            location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + arg.data.url.toLowerCase() + getSdkQueryString() + '#/' + theme;
                        }
                        else {
                            location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + defaultSample[0].url.toLowerCase() + getSdkQueryString() + '#/' + theme;
                        }
                    }
                    else {
                        location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + arg.data.url.toLowerCase() + getSdkQueryString() + '#/' + theme;
                    }
                }
            } else {
                var hashName = location.hash.length ? '' : '#/' + theme
                location.href = location.href + hashName;
            }
        }
    }
}

function controlListRefresh(ele) {
    var samples = controlSampleData[ele.getAttribute('control-name')];
    // var samples = controlSampleData[location.href.split('/')[3]];
    if (samples) {
        var listView = ej.base.select('#controlList').ej2_instances[0];
        listView.dataSource = samples;
        showHideControlTree();
    }
}

function showHideControlTree() {
    var controlTree = ej.base.select('#controlTree');
    var controlList = ej.base.select('#controlSamples');
    var reverse = ej.base.select('#controlTree').style.display === 'none';
    if (reverse) {
        viewSwitch(controlList, controlTree, reverse);

    } else {
        viewSwitch(controlTree, controlList, reverse);
    }
     const url = location.pathname;
     const pathParts = url.split("/");
     const sampleName = pathParts[pathParts.length - 2];
     const listItem = document.querySelector(`li[control-name="${sampleName}"]`);
     if (listItem) {
        listItem.classList.add('e-active');
     }
     const selectedDiv = document.querySelector('.e-active');
     if (selectedDiv) 
     {
          selectedDiv.scrollIntoView({
                        block: 'center'
                        });
      }
}

function viewSwitch(from, to, reverse) {
    var anim = new ej.base.Animation({ duration: 500, timingFunction: 'ease' });
    var controlTree = ej.base.select('#controlTree');
    var controlList = ej.base.select('#controlList');
    controlTree.style.overflowY = 'hidden';
    controlList.classList.remove('e-view');
    controlList.classList.remove('sb-control-list-top');
    controlList.classList.add('sb-adjust-juggle');
    to.style.display = '';
    anim.animate(from, {
        name: reverse ? 'SlideRightOut' : 'SlideLeftOut',
        end: function () {
            controlTree.style.overflowY = 'auto';
            from.style.display = 'none';
            controlList.classList.add('e-view');
            controlList.classList.add('sb-control-list-top');
            controlList.classList.remove('sb-adjust-juggle');
        }
    });
    anim.animate(to, { name: reverse ? 'SlideLeftIn' : 'SlideRightIn' });
}

function setSelectList() {
    var hString = location.pathname;
    var hash = hString.split('/');
    var list = ej.base.select('#controlList').ej2_instances[0];
    var sampleName = hash.slice(-2)[1];
    var selectSample = ej.base.select('[sample-name="' + sampleName.replace('#', '') + '"]') || ej.base.select('[sample-name="' + list.localData[0].url.toLowerCase() + '"]');
    if (selectSample) {
        if (ej.base.select('#controlTree').style.display !== 'none') {
            showHideControlTree();
        }
        list.selectItem(selectSample);
    } else {
        showHideControlTree();
        list.selectItem(ej.base.select('[sample-name="line"]'));
    }
}

function toggleButtonState(id, state) {
    var ele = document.getElementById(id);
    var mobileEle = document.getElementById('mobile-' + id);
    ele.disabled = state;
    mobileEle.disabled = state;
    if (state) {
        mobileEle.classList.add('e-disabled');
        ele.classList.add('e-disabled');
    } else {
        mobileEle.classList.remove('e-disabled');
        ele.classList.remove('e-disabled');
    }
}

function setPropertySectionHeight() {
    if (!isTablet && !isMobile) {
        var propertypane = ej.base.select('.property-section');
        var ele = document.querySelector('.control-section');
        if (ele && propertypane) {
            ele.classList.add('sb-property-border');
        } else {
            ele.classList.remove('sb-property-border');
        }
    }
}




function errorHandler(error) {
    //  document.getElementById('control-content').innerHTML = error ? error : 'Not Available';
    // ej.base.select('#control-content').classList.add('error-content');
    removeOverlay();
}

function sampleArray() {
    for (var node in samplesList) {
        var dataManager = new ej.data.DataManager(samplesList[node].samples);
        var samples = dataManager.executeLocal(new ej.data.Query().sortBy('order', 'ascending'));
        for (var sample in samples) {
            var selectedTheme = location.hash.split('/')[1] ? location.hash.split('/')[1] : defaultTheme;
            var control = samplesList[node].directory.toLowerCase();
            var sampleUrl = samples[sample].url.toLowerCase();
            var loc = control + '/' + sampleUrl;
            samplesAr.push(loc);
        }
    }
}

function addRoutes(samplesList) {
    // Check if the current sample path exists in the filtered samplesList
    var currentPath = getSamplePath();
    var currentSampleExists = false;

    var loop1 = function (node) {
        var dataManager = new ej.data.DataManager(node.samples);
        var samples = dataManager.executeLocal(new ej.data.Query().sortBy('order', 'ascending'));
        var loop2 = function (subNode) {
            var control = node.directory.toLowerCase();
            var sample = subNode.url.toLowerCase();
            samplePath = samplePath.concat(control + '/' + sample);
            var sampleName = node.name + ' / ' + ((node.name !== subNode.category) ?
                (subNode.category + ' / ') : '') + subNode.url.toLowerCase();
            var selectedTheme = location.hash.split('/')[1] ? location.hash.split('/')[1] : defaultTheme;
            var urlString = control + '/' + sample;
            if (getSamplePath() == urlString) {
                currentSampleExists = true;
                var dataSourceLoad = document.getElementById(node.dataSourcePath);
                if (node.dataSourcePath && !dataSourceLoad) {
                    var dataAjax = new ej.base.Ajax(node.dataSourcePath, 'GET', true);
                    dataAjax.send().then(function (result) {
                        var ele = ej.base.createElement('script', { id: node.dataSourcePath, innerHTML: result });
                        document.getElementsByTagName('head')[0].appendChild(ele);
                        onDataSourceLoad(node, subNode, control, sample, sampleName);
                    });
                } else {
                    onDataSourceLoad(node, subNode, control, sample, sampleName);
                }
            }
        };
        for (var i = 0; i < samples.length; i++) {
            var subNode = samples[i];
            loop2(subNode);
        }
    };
    for (var i = 0; i < samplesList.length; i++) {
        var node = samplesList[i];
        loop1(node);
    }

    // If the current sample doesn't exist in the filtered list, redirect to the first available sample
    if (!currentSampleExists && samplesList.length > 0) {
        var firstNode = samplesList[0];
        var firstDataManager = new ej.data.DataManager(firstNode.samples);
        var firstSamples = firstDataManager.executeLocal(new ej.data.Query().sortBy('order', 'ascending'));
        if (firstSamples.length > 0) {
            var firstControl = firstNode.directory.toLowerCase();
            var firstSample = firstSamples[0].url.toLowerCase();
            var currentTheme = location.hash.split('/')[1] || defaultTheme;
            // Preserve the sdk query string if present
            var sdkQuery = location.search || '';
            var newUrl = location.origin + location.pathname.split('/').slice(0, -2).join('/') + '/' + firstControl + '/' + firstSample + sdkQuery + '#/' + currentTheme;
            location.replace(newUrl);
        }
    }
}

function onDataSourceLoad(node, subNode, control, sample, sampleName) {
    var controlID = node.uid;
    var sampleID = subNode.uid;
    var subNodeDir = subNode.dir;
    var subNodeUrl = subNode.url;
    setSbLink();
    // Checking whether the OS is Linux or not. If not we are converting the dir and url to lower case.
    if(window.navigator.userAgent.indexOf("Linux") == -1){
        subNodeDir = subNode.dir.toLowerCase();
        subNodeUrl = subNode.url.toLowerCase();
    }
    var ajaxCS = new ej.base.Ajax(baseurl + 'Pages/' + subNodeDir + '/' + subNodeUrl + '.cshtml.cs', 'GET', false);
    var ajaxCSHTML = new ej.base.Ajax(baseurl + 'Pages/' + subNodeDir + '/' + subNodeUrl + '.cshtml', 'GET', false);
    var add = [ajaxCSHTML, ajaxCS];
    var cs = subNodeUrl + '.cshtml.cs';
    var cshtml = subNodeUrl + '.cshtml';
    var name = [cshtml, cs];
    //var p2 = loadScriptfile('src/' + control + '/' + sample + '.js');
    //var ajaxJs = new ej.base.Ajax('src/' + control + '/' + sample + '.js', 'GET', true);
    //sampleNameElement.innerHTML = node.name;
    breadCrumbComponent.innerHTML = node.name;
    if (node.name !== subNode.category) {
        breadCrumbSubCategory.innerHTML = subNode.category;
        breadCrumbSubCategory.style.display = '';
        breadCrumSeperator.style.display = '';
    } else {
        breadCrumbSubCategory.style.display = 'none';
        breadCrumSeperator.style.display = 'none';
    }
    if (location.pathname.indexOf('/' + subNode.dir.toLowerCase() + '/' + subNode.url.toLowerCase()) !== -1) {
        breadCrumbSample.innerHTML = subNode.name;
    }
    if (subNode.sourceFiles) {
        add=[];
        name=[];
        for (var i = 0; i < subNode.sourceFiles.length; i++) {
            var ajaxAdd = new ej.base.Ajax(subNode.sourceFiles[i].path, 'GET', false);
            add.push(ajaxAdd);
            var optional = subNode.sourceFiles[i].displayName;
            name.push(optional);
        }
    }
    var subfile = 0;
    for (var file = 0; file < add.length; file++) {
        add[file].send().then(function (value) {
            var content;
            if (/html/g.test(name[subfile])) {
                value = value.replace(/@section (ActionDescription|Title|Description|Meta|Header){[^}]*}/g, '').trim();
                content = value.replace(/&/g, '&amp;')
                    .replace(/"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
            }
            else {
                content = value.replace(/&/g, '&amp;')
                    .replace(/"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
            }
            items.push({
                header: { text: name[subfile] },
                data: content,
                content: name[subfile]
            })
            subfile++;
        });
    }
    ArrayItem = items;
        currentControlID = controlID;
        currentSampleID = sampleID;
        currentControl = node.directory.toLowerCase();
        var curIndex = samplesAr.indexOf(getSamplePath());
        var samLength = samplesAr.length - 1;
        if (curIndex === samLength) {
            toggleButtonState('next-sample', true);
        } else {
            toggleButtonState('next-sample', false);
        }
        if (curIndex === 0) {
            toggleButtonState('prev-sample', true);
        } else {
            toggleButtonState('prev-sample', false);
        }
        ej.base.select('#control-content').classList.remove('error-content');
        renderPropertyPane('#property');
        initializePropertyPanels();
        window.navigateSample();
        isExternalNavigation = defaultTree = false;
        setPropertySectionHeight();
        removeOverlay();
        var mobilePropPane = ej.base.select('.sb-mobile-prop-pane .property-section');
        if (mobilePropPane) {
            ej.base.detach(mobilePropPane);
        }
        var propPanel = ej.base.select('#control-content .property-section');
        var isLandscapeTablet = window.matchMedia('(max-width: 1024px)').matches;
        if (isLandscapeTablet) {
            if (propPanel) {
                propPanel.classList.remove('panel-hidden');
                propPanel.style.removeProperty('width');
                var mobileSetting = ej.base.select('.sb-mobile-setting');
                if (mobileSetting) {
                    mobileSetting.classList.add('sb-hide');
                }
            }
        }
}
function initializeGTM() {
    setTimeout(function () {
        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'gtm.start':
                    new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
                j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                    'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-P3WXFWCW');

        (function (w, d, s, l, i) {
            w[l] = w[l] || []; w[l].push({
                'gtm.start':
                    new Date().getTime(), event: 'gtm.js'
            }); var f = d.getElementsByTagName(s)[0],
                j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                    'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-W8WD8WN');
    }, 500);
}

function loadStylesheet(href) {
    const link = document.createElement("link");
    link.rel = "stylesheet";
    link.href = href;
    document.head.appendChild(link);
}

function loadScript(src, integrity) {
    const script = document.createElement("script");
    script.src = src;
    script.type = "text/javascript";
    if (integrity) {
        script.crossOrigin = "anonymous";
        script.integrity = integrity;
    }
    document.head.appendChild(script);
}

function removeOverlay() {
    const cssSuffix = isStaging ? ".min" : "";
    loadStylesheet(window.baseurl + "styles/highlight" + cssSuffix + ".css");
    loadStylesheet(window.baseurl + "css/roboto" + cssSuffix + ".css");
    loadStylesheet(window.baseurl + "css/site" + cssSuffix + ".css");
    if (window.location.href.includes("richtexteditor/onlinehtmleditor") || window.location.href.includes("richtexteditor/overview") || window.location.href.includes("richtexteditor/enterkeyconfiguration")) {
        loadStylesheet(window.baseurl + "css/richtexteditor/codemirror" + cssSuffix + ".css");
        const scripts = [
            {
                src: "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/mode/css/css.js",
                integrity: "sha384-bx2UEHmkahlrzAHJQxatI4mjOrSrRKEmueT3DZSS3OY392BXvcqXcgUqWnse30VV"
            },
            {
                src: "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/mode/xml/xml.js",
                integrity: "sha384-83KFdJ/lJGxIW+p+cbX3MI8vwU/s+pQbv42uek9/nt283oRLzP8YJ2J7uSBgoRuw"
            },
            {
                src: "https://cdnjs.cloudflare.com/ajax/libs/codemirror/5.3.0/mode/htmlmixed/htmlmixed.js",
                integrity: "sha384-yUJOFmuHndKeGdERelLizdhzB2ghbvBSFWMcE7z3t5kOERXoOwvNQhYTAvjiZV80"
            }
        ];

        scripts.forEach(({ src, integrity }) => {
            loadScript(src, integrity);
        });
    }
    setTimeout(function () {
        document.body.setAttribute('aria-busy', 'false');
        sbContentOverlay.classList.add('sb-hide');
        sbRightPane.classList.remove('sb-right-pane-overlay');
        sbHeader.classList.remove('sb-right-pane-overlay');
        mobNavOverlay(false);
        if (!sbBodyOverlay.classList.contains('sb-hide')) {
            sbBodyOverlay.classList.add('sb-hide');
            initializeGTM();
        }
        sbRightPane.scrollTop = 0;
    }, 400)
}

function sampleOverlay() {
    document.body.setAttribute('aria-busy', 'true');
    //sbHeader.classList.add('sb-right-pane-overlay');
    //sbRightPane.classList.add('sb-right-pane-overlay');
    mobNavOverlay(true);
    //  sbContentOverlay.classList.remove('sb-hide');
}

function overlay() {
    sbHeader.classList.add('sb-right-pane-overlay');
    sbBodyOverlay.classList.remove('sb-hide');
}

function mobNavOverlay(isOverlay) {
    if (ej.base.isDevice) {
        var mobileFoorter = ej.base.select('.sb-mobilefooter');
        if (isOverlay) {
            mobileFoorter.classList.add('sb-right-pane-overlay');
        } else {
            mobileFoorter.classList.remove('sb-right-pane-overlay');
        }
    }
}


function parseHash(newHash, oldHash) {
    var newTheme = newHash.split('/')[0];
    var control = newHash.split('/')[1];
    if (newTheme !== selectedTheme && themes.indexOf(newTheme) !== -1) {
        location.reload();
        crossroads.parse(newHash);
    }
    /* if (newHash.length && !ej.base.select('#' + control + '-common') && checkSampleLength(control)) {
         var scriptElement = document.createElement('script');
         scriptElement.src = 'src/' + control + '/common.js';
         scriptElement.id = control + '-common';
         scriptElement.type = 'text/javascript';
         scriptElement.onload = function () {
             crossroads.parse(newHash);
         };
         document.getElementsByTagName('head')[0].appendChild(scriptElement);
     }*/

    crossroads.parse(newHash);
}


function processDeviceDependables() {
    if (ej.base.Browser.isDevice) {
        ej.base.select('.sb-desktop-setting').classList.add('sb-hide');
    } else {
        ej.base.select('.sb-desktop-setting').classList.remove('sb-hide');
    }
}


function renderPropertyPane(ele) {
    var contentEle = ej.base.select('#control-content');
    var elem = contentEle.querySelector(ele);
    var title;
    if (!elem) {
        return;
    }
    title = elem.getAttribute('title');
    var parentEle = elem.parentElement;
    elem = ej.base.detach(elem);
    elem.classList.add('property-panel-table');
    var parentPane = ej.base.createElement('div', {
        className: 'property-panel-section',
        innerHTML: "<div class=\"property-panel-header\">" + title + "</div><div class=\"property-panel-content\"></div>"
    });
    parentPane.children[1].appendChild(elem);
    parentEle.appendChild(parentPane);
}

function loadJSON() {
    var storedSwitch = localStorage.getItem('ej2-switch');
    var switchText;
    if (window.screen.width < 768) {
        switchText = 'touch';
    } else if (storedSwitch) {
        switchText = storedSwitch;
    } else {
        switchText = 'mouse';
    }
    setLeftPaneHeight();
    if (isMobile) {
        ej.base.select('.sb-left-footer-links').appendChild(ej.base.select('.sb-footer-left'));
        ej.base.select('.sb-mobile-left-pane').appendChild(ej.base.select('.sb-left-pane'));
        leftToggle.classList.remove('toggle-active');
    }
    /**
     * Tab View
     */
    if (isTablet || (ej.base.Browser.isDevice && isPc)) {
        leftToggle.classList.remove('toggle-active');
        ej.base.select('.sb-left-pane').classList.add('sb-hide');
        ej.base.select('.sb-right-pane').classList.add('control-fullview');
    }

    //overlay();
    changeMouseOrTouch(switchText);
    // localStorage.removeItem('ej2-switch');
    ej.base.enableRipple(selectedTheme?.indexOf('material3') !== -1 || !selectedTheme);
    loadTheme(selectedTheme);
    loadCulture();
}
loadJSON();

document.addEventListener('keydown', function (e) {
        var popup = document.getElementById('sdk-switcher-popup');
        if (!popup) { return; }
        var isOpen = popup.classList.contains('e-popup-open') ||
                     (popup.style && popup.style.display !== 'none' && popup.offsetParent !== null);
        var key = e.key;
        if (key === 'ArrowDown' || key === 'ArrowUp' || key === 'Enter' || key === 'Escape') {
            if (key === 'Enter' && !isOpen && e.target &&
                (e.target.id === 'header-sdk-switcher' ||
                 e.target.id === 'header-sdk-switcher-mobile' ||
                 (typeof e.target.closest === 'function' &&
                  (e.target.closest('#header-sdk-switcher') || e.target.closest('#header-sdk-switcher-mobile'))))) {
                e.preventDefault();
                e.target.click();
                return;
            }
            if (!isOpen) { return; }
            handleSdkKeyboard(e);
        }
    });

function ScrollToSelected() {
    const selectedDiv = document.querySelector('.sb-left-pane .e-listview .e-list-item.e-active');
    if (!selectedDiv) {
        return;
    }
    if (isMobile) {
        const scrollContainer = document.querySelector('.sb-left-pane');
        if (!scrollContainer) {
            return;
        }
        const containerRect = scrollContainer.getBoundingClientRect();
        const selectedRect = selectedDiv.getBoundingClientRect();
        const topOffset = 90;
        scrollContainer.scrollTop += selectedRect.top - containerRect.top - topOffset;
        return;
    }
    selectedDiv.scrollIntoView({ block: 'center' });
}

window.addEventListener('load', function () {
    // Initialize controlSampleData from the full unfiltered list after page load
    if (typeof initializeAllControlSampleData === 'function') {
        initializeAllControlSampleData();
    }
    // Get the meta description content
    const metaDescription = document.querySelector('meta[name="description"]')?.getAttribute('content');
    // Get the page title
    const pageTitle = document.title;
    var pageUrl = window.location.href;
    const imageUrl = 'https://cdn.syncfusion.com/content/images/company-logos/Syncfusion_Logo_Image.png';


    // Open Graph Tags
    setMetaTags({
        'og:title': pageTitle,
        'og:description': metaDescription,
        'og:url': pageUrl,
        'og:image': imageUrl,
        'og:type': 'website'
    }, 'property');
    
    // Twitter Tags
    setMetaTags({
        'twitter:account_id': '41152441',
        'twitter:url': pageUrl,
        'twitter:title': pageTitle,
        'twitter:card': 'summary',
        'twitter:description': metaDescription,
        'twitter:image': imageUrl
    }, 'name');

    // JSON-LD Structured Data (WebApplication + BreadcrumbList)
    (function () {
        var origin = window.location.origin;
        var pathParts = window.location.pathname.split('/').filter(function (p) { return p; });
        var breadcrumbItems = [];
        // Home entry
        breadcrumbItems.push({
            "@type": "ListItem",
            "position": 1,
            "name": "Home",
            "item": origin + '/'
        });
        for (var i = 0; i < pathParts.length; i++) {
            var name = decodeURIComponent(pathParts[i]).replace(/[-_]/g, ' ');
            name = name.charAt(0).toUpperCase() + name.slice(1);
            breadcrumbItems.push({
                "@type": "ListItem",
                "position": i + 2,
                "name": name,
                "item": origin + '/' + pathParts.slice(0, i + 1).join('/') + '/'
            });
        }

        setJsonLd({
            "@context": "https://schema.org",
            "@graph": [
                {
                    "@type": "WebApplication",
                    "@id": origin + '/',
                    "name": pageTitle || document.title || 'Syncfusion Samples',
                    "headline": pageTitle || document.title,
                    "description": metaDescription || document.querySelector('meta[name="description"]')?.getAttribute('content') || '',
                    "applicationCategory": "DeveloperApplication",
                    "operatingSystem": "Web",
                    "url": pageUrl,
                    "publisher": {
                        "@type": "Organization",
                        "name": "Syncfusion",
                        "logo": {
                            "@type": "ImageObject",
                            "url": "https://www.syncfusion.com/favicon.ico"
                        }
                    }
                },
                {
                    "@type": "BreadcrumbList",
                    "@id": pageUrl + '#breadcrumb',
                    "itemListElement": breadcrumbItems
                }
            ]
        });
    })();
});


//Appends Open Graph meta tags for link previews on social media platforms like Facebook and LinkedIn.These tags define how the page title, description, URL, and image are displayed when shared.

function setMetaTags(tags, attrType) {
    const head = document.getElementsByTagName('head')[0];
    for (const [key, value] of Object.entries(tags)) {
        let meta = document.querySelector(`meta[${attrType}='${key}']`);
        if (!meta) {
            meta = document.createElement('meta');
            meta.setAttribute(attrType, key);
            head.appendChild(meta);
        }
        meta.setAttribute('content', value);
    }
}


function setJsonLd(data) {
    let script = document.querySelector('script[type="application/ld+json"]');
    if (!script) {
        script = document.createElement('script');
        script.type = 'application/ld+json';
        document.head.appendChild(script);
    }
    script.textContent = JSON.stringify(data);
}


document.addEventListener("DOMContentLoaded", function () { setTimeout(function () { ScrollToSelected(); }, 500); });

//on load for mobile mode
window.addEventListener('resize', ScrollToSelected);

// Get the button element
var button = document.getElementById('buttoncolor');

// Attach click event listener to the button
button.addEventListener('click', function () {
    // Call the navigateToPage function when the button is clicked
    navigateToPage();
});

// Mode switcher handler for devices
function onModeChanges(event) {
    var currentURL = window.location.href;
    var updatedURL1 = "";
    if (!currentURL.includes("highcontrast") && !currentURL.includes("fluent2-highcontrast") && !currentURL.includes("bootstrap4")) {
        // Check if the URL already contains "-dark"
        if (!currentURL.includes("-dark")) {
            // Append "-dark" to the current URL
            updatedURL1 = currentURL;
            window.location.href = updatedURL1;
        } else if (currentURL.includes("-dark")) {
            // Remove "-dark" from the current URL
            updatedURL1 = currentURL.replace("-dark", "");
            window.location.href = updatedURL1;
            location.reload();
        }
        if (event.itemData.ThemeId === "dark") {
            updatedURL1 += "-dark";
            window.location.href = updatedURL1;
            location.reload();
        }
    }
}
function updateThemeURL() {
    var current_URL = window.location.href;
    var updatedURL = current_URL;

    if (current_URL.includes("#/")) {
        var urlParts = current_URL.split("#/");
        var baseUrl = urlParts[0];
        var hashValue = urlParts[1]; // Rename 'hash' to 'hashValue'
        if (hashValue.includes("-dark")) {
            // Remove "-dark" from the hash 
            hashValue = hashValue.replace("-dark", "");
        } else {
            // Append "-dark" to the hash
            hashValue = hashValue + "-dark";
        }
        updatedURL = baseUrl + "#/" + hashValue;
    } else {
       // console.log("");
    }
    // Return the updated URL
    return updatedURL;
}

function navigateToPage() {
    var updatedURL = updateThemeURL();
    localStorage.setItem('PreviousURL', updatedURL);
    window.location.href = updatedURL;
    location.reload();
}

const themePopup = document.querySelector('#theme-switcher-popup');
const settingspopup = document.querySelector('#settings-popup');
const sdkPopup = document.querySelector('#sdk-switcher-popup');

// Function to close the popup
function closePopup() {
    const popups = [themePopup, settingspopup, sdkPopup];
    popups.forEach(popup => {
        if (popup?.classList.contains('e-popup-open')) {
            popup.classList.remove('e-popup-open');
            popup.classList.add('e-popup-close');
        }
    });
}

// Add event listener for window resize
window.addEventListener('resize', closePopup);


// Session based AI tokens for users
async function fingerPrint() {
    try {
        var canvas = document.body.appendChild(document.createElement('canvas'));
        canvas.width = 600;
        canvas.height = 300;
        canvas.style.display = "none";
        const ctx = canvas.getContext("2d");
        const size = 24;
        const diamondSize = 28;
        const gap = 4;
        const startX = 30;
        const startY = 30;
        const blue = "#1A3276";
        const orange = "#F28C00";
        const colorMap = [
            ["blue", "blue", "diamond"],
            ["blue", "orange", "blue"],
            ["blue", "blue", "blue"]
        ];
        function drawSquare(x, y, color) {
            ctx.fillStyle = color;
            ctx.fillRect(x, y, size, size);
        }
        function drawDiamond(centerX, centerY, size, color) {
            ctx.fillStyle = color;
            ctx.beginPath();
            ctx.moveTo(centerX, centerY - size / 2);
            ctx.lineTo(centerX + size / 2, centerY);
            ctx.lineTo(centerX, centerY + size / 2);
            ctx.lineTo(centerX - size / 2, centerY);
            ctx.closePath();
            ctx.fill();
        }
        for (let row = 0; row < 3; row++) {
            for (let col = 0; col < 3; col++) {
                const type = colorMap[row][col];
                const x = startX + col * (size + gap);
                const y = startY + row * (size + gap);
                if (type === "blue") drawSquare(x, y, blue);
                else if (type === "orange") drawSquare(x, y, orange);
                else if (type === "diamond") drawDiamond(x + size / 2, y + size / 2, diamondSize, orange);
            }
        }
        ctx.font = "20px Arial";
        ctx.fillStyle = blue;
        ctx.textBaseline = "middle";
        ctx.fillText("Syncfusion", startX + 3 * (size + gap) + 20, startY + size + gap);

        // --- Add device-variant text for extra fingerprint uniqueness ---
        const text = "❁ 🧬 Fingerprint Data 🍌: Render & Hash Now!";
        ctx.font = "14px 'Arial'";
        ctx.textBaseline = "alphabetic"
        ctx.fillStyle = "#f60";
        ctx.fillRect(125, 110, 62, 20);
        ctx.fillStyle = "#069";
        ctx.fillText(text, 2, 130);
        ctx.fillStyle = "rgba(102, 204, 0, 0.7)";
        ctx.fillText(text, 4, 132);

        // --- Canvas blending shapes ---
        ctx.globalCompositeOperation = "multiply";
        ctx.fillStyle = "rgb(255,0,255)";
        ctx.beginPath(); ctx.arc(50, 200, 50, 0, Math.PI * 2); ctx.fill();
        ctx.fillStyle = "rgb(0,255,255)";
        ctx.beginPath(); ctx.arc(100, 200, 50, 0, Math.PI * 2); ctx.fill();
        ctx.fillStyle = "rgb(255,255,0)";
        ctx.beginPath(); ctx.arc(75, 250, 50, 0, Math.PI * 2); ctx.fill();

        // --- Winding Rule Shape ---
        ctx.fillStyle = "rgb(255,0,255)";
        ctx.beginPath();
        ctx.arc(200, 200, 75, 0, Math.PI * 2, true);
        ctx.arc(200, 200, 25, 0, Math.PI * 2, true);
        ctx.fill("evenodd");
        const sha256 = async function (str) {
            const encoder = new TextEncoder();
            const data = encoder.encode(str);
            const hashBuffer = await crypto.subtle.digest('SHA-256', data);
            const hashArray = Array.from(new Uint8Array(hashBuffer));
            return hashArray.map(b => b.toString(16).padStart(2, '0')).join('');
        };

        const visitorID = sha256(canvas.toDataURL());
        return visitorID;
    }
    catch (error) {
        console.error(error);
        return null;
    }
}

async function getRemainingTokens(userId) {
    try {
        const baseElement = document.querySelector('base');
        const baseUrl = getAbsoluteURL();
        const response = await fetch(`${baseUrl}api/UserTokens/get_remaining_tokens/${userId}`);
        if (response.ok) {
            return await response.json();
        }
    } catch (error) {
        console.error("Error fetching remaining tokens:", error);
    }
    return 0;
}

// Function to create and show a banner at the top of the application
function showBanner(messageText) {
    // Check if the banner already exists
    if (document.getElementById("custom-banner")) {
        return;
    }

    // Create the banner container
    let banner = document.createElement("div");
    banner.id = "custom-banner";
    banner.className = "e-banner";

    // Banner content
    let message = document.createElement("p");
    message.innerHTML = messageText;
    message.className = "banner-message";

    // Create the close button
    let closeButton = document.createElement("span");
    closeButton.innerHTML = "&times;"; // HTML entity for '×' symbol
    closeButton.className = "close-button";
    closeButton.onclick = closeBanner;

    // Append elements
    banner.appendChild(message);
    banner.appendChild(closeButton);
    document.body.insertBefore(banner, document.body.firstChild);
}

// Function to close the banner
function closeBanner() {
    let banner = document.getElementById("custom-banner");
    if (banner) {
        document.body.removeChild(banner);
    }
}

// Toggle open/close
function toggleNotification() {
    sbHeaderClick('closePopup', true);
    if (!searchOverlay.classList.contains('sb-hide')) {
        toggleSearchOverlay();
    }
    var popup = document.querySelector('.sb-notification-popup');
    var overlay = document.querySelector('.sb-notification-overlay');
    if (!popup || !overlay) return;

    var isHidden = popup.classList.contains('sb-hide');
    if (isHidden) {
        buildNotifications(); // build on open
        popup.classList.remove('sb-hide');
        popup.classList.add('active');
        overlay.classList.remove('sf-hidden');
    } else {
        popup.classList.add('sb-hide');
        popup.classList.remove('active');
        overlay.classList.add('sf-hidden');
    }
}

function hideNotification(e) {
    var popup = document.querySelector('.sb-notification-popup');
    var overlay = document.querySelector('.sb-notification-overlay');
    if (!popup || !overlay) return;

    popup.classList.add('sb-hide');
    popup.classList.remove('active');
    overlay.classList.add('sf-hidden');
}

function notificationKeyDown(e) {
    if (e.key === 'Escape') hideNotification(e);
    if (e.key === 'Enter') toggleNotification();
}

  // Build notifications from window.samplesList
function buildNotifications() {
    var container = document.getElementById('notificationBody');
    if (!container) return;

    var data = (window.samplesList || []);
    var compUpdates = data.filter(function (component){
        var notificationType = (component.type || '').toString().toLowerCase();
        var hasDesc = component.notificationDescription && String(component.notificationDescription).trim() !== '';
        return (notificationType === 'new' || notificationType === 'update') && hasDesc;
    });

    var sampleUpdates = [];
    data.forEach(function (component) {
        var updates = (component.samples || []).filter(function(sample) {
        var notificationType = (sample.type || '').toString().toLowerCase();
            var hasDesc = sample.notificationDescription && String(sample.notificationDescription).trim() !== '';
            return (notificationType === 'new' || notificationType === 'update') && hasDesc;
        });
        if (updates.length) {
            sampleUpdates.push({ name: component.name, directory: component.directory, samples: updates });
        }
    });
    var html = '';

    // Sample-level updates
    var hadAnySample = false;
    sampleUpdates.forEach(function(group) {
        hadAnySample = true;
        var compPath = ('/' + (group.directory || '')).toLowerCase();

        var samplesHtml = '';
        group.samples.forEach(function(sample) {
        // Creates sampleUrl for View Demo in notification popup for each sample
        var pathname = window.location.pathname;
        const parts = pathname.split('/').filter(Boolean);
        parts.splice(-2, 2);
        let result = ''
        if (parts != 0) { result = '/' + parts.join('/'); }
        var sampleUrl = ((result) + '/' + (group.directory || '') + '/' + (sample.url || '')).toLowerCase();
        
        var listClass = 'sb-notification-list list-type-none';
        var notes = sample.notificationDescription ? sample.notificationDescription : [labelForType(sample.type)];

        samplesHtml += `
            <div class="sb-notification-list-container">
            <div class="sb-notification-sample">
                ${escapeHtml(sample.name || 'Sample')} -
                <span class="sb-Notification-link-label">
                <a href="${sampleUrl}" target="_blank" aria-label="View Demo">View Demo</a>
                </span>
            </div>
            <ul class="${listClass}">
                <li>${notes}</li>
            </ul>
            </div>`;
        });

        html += `
        <div class="sb-notification-content-container">
            <div class="sb-notification-content">
            <div class="sb-notification-category">
                <a href="${compPath}" target="_blank" aria-label="Component name">
                ${escapeHtml(group.name || 'Component')}
                </a>
            </div>
            ${samplesHtml}
            </div>
        </div>`;
    });

    if (!compUpdates.length && !hadAnySample) {
        html = '<span class="sb-notifiction-Update">No new updates available.</span>';
    }

    container.innerHTML = html;
}

  // Helpers
function labelForType(t) {
    var v = (t || '').toString().toLowerCase();
    if (v === 'new') return 'New';
    if (v === 'update' || v === 'updated') return 'Updated';
    return 'Change';
}

function escapeHtml(str) {
    return (str || '').toString()
        .replace(/&/g,'&amp;').replace(/</g,'&lt;')
        .replace(/>/g,'&gt;').replace(/"/g,'&quot;')
        .replace(/'/g,'&#39;');
}

function initializeNotificationSystem() {
    const STORAGE_KEY = 'sbNotificationSeen';
    const VERSION_KEY = 'sbNotificationVersion';
    const CURRENT_VERSION = '32.1.19'; // Update this with each release

    function getDot() {
        return document.querySelector('.sb-notification-btn .e-badge-dot');
    }

    function removeDot() {
        const dot = getDot();
        if (dot && dot.parentElement) {
            dot.parentElement.removeChild(dot);
        }
    }

    function markSeen() {
        if (localStorage.getItem(STORAGE_KEY) === '1') return;
        localStorage.setItem(STORAGE_KEY, '1');
        removeDot();
    }

    function checkVersionUpdate() {
        const storedVersion = localStorage.getItem(VERSION_KEY);
        
        // If version changed, reset notification and show dot
        if (storedVersion !== CURRENT_VERSION) {
            localStorage.setItem(VERSION_KEY, CURRENT_VERSION);
            localStorage.removeItem(STORAGE_KEY); // Reset seen status
            return true; // New version detected
        }
        return false; // Same version
    }

    function handleStorageChange(e) {
        // This event fires in OTHER windows when localStorage changes
        if (e.key === STORAGE_KEY && e.newValue === '1') {
            removeDot();
        }
        if (e.key === VERSION_KEY && e.newValue !== CURRENT_VERSION) {
            checkVersionUpdate();
        }
    }

    function wire() {
        var popupEle = document.querySelector('.sb-notification-popup');
        var header = document.querySelector('.sb-header');
        var switchPopup = document.getElementById('sb-popup-section');
        if (!popupEle || !header) return;

        var isHidden = popupEle.classList.contains('sb-hide');
        if (isHidden) {
            header.classList.remove('sf-hidden');
            switchPopup.classList.remove('sf-hide');
        } else {
            header.classList.add('sf-hidden');
            switchPopup.classList.add('sf-hide');
        }

        // Check for version update first
        const isNewVersion = checkVersionUpdate();
        // If already seen before and no new version, remove dot immediately and return.
        if (localStorage.getItem(STORAGE_KEY) === '1' && !isNewVersion) {
            removeDot();
            return;
        }
        else {
            var element = document.querySelector('.sb-notification-btn .e-badge-dot');
            if (element) {
                element.classList.remove('e-badge-showdot');
            }
        }

        const overlay = document.querySelector('.sb-notification-overlay');
        const popup = document.querySelector('.sb-notification-popup');
        const clearIcon = document.querySelector('.sb-notification-clear-icon');

        // Listen for storage changes from other windows
        window.addEventListener('storage', handleStorageChange);

        // When the overlay is clicked, mark as seen.
        if (overlay) {
            overlay.addEventListener('click', function () {
                markSeen();
            }, true);
        }

        // When the "clear" icon is clicked, mark as seen.
        if (clearIcon) {
            clearIcon.addEventListener('click', function () {
                markSeen();
            }, true);
        }

        // If the popup is closed via Esc key, mark as seen.
        document.addEventListener('keydown', function (e) {
            if ((e.key === 'Escape' || e.key === 'Esc') && overlay && !overlay.classList.contains('sf-hidden')) {
                markSeen();
            }
        });
    }

    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', wire);
    } else {
        wire();
    }
}
// Initialize property panel for each property-section on the page
function initializePropertyPanels() {
    let controlContent = document.getElementById('control-content');
    let propertySection = document.querySelector('.property-section');
    let oldBtn = controlContent.querySelector('.property-panel-toggle-icon');
    let controlSection = document.querySelector('.control-section');
    if (!propertySection || !controlContent || !controlSection) {
        return;
    }
    if (oldBtn) {
        oldBtn.remove();
    }
    if (isPropertyPanelOpen) {
        propertySection.classList.remove('add-transition');
        controlSection.classList.remove('add-transition');
        propertySection.classList.add('panel-hidden');
        controlSection.style.borderRight = 'none';
        controlSection.style.width = '97%';
        propertySection.style.width = '3%';
        isPropertyPanelOpen = false;
        void controlSection.offsetWidth;
        resizeManualTrigger = true;
        window.dispatchEvent(new Event('resize'));
        resizeManualTrigger = false;
        requestAnimationFrame(function () {
            propertySection.classList.add('add-transition');
            controlSection.classList.add('add-transition');
        });
    }
    const buttonDiv = document.createElement('div');
    buttonDiv.className = 'property-panel-toggle-icon';
    buttonDiv.setAttribute('role', 'button');
    buttonDiv.setAttribute('aria-label', 'Toggle Property Panel');
    buttonDiv.setAttribute('title', 'Toggle Property Panel');
    const spanIcon = document.createElement('span');
    spanIcon.className = 'e-icons e-settings';
    buttonDiv.appendChild(spanIcon);
    controlContent.appendChild(buttonDiv);
    buttonDiv.addEventListener('click', function () {
    if (isPropertyPanelOpen) {
        setTimeout(function () {
            propertySection.classList.add('panel-hidden');
        }, 150);
        requestAnimationFrame(function () {
            controlSection.style.width = '97%';
            controlSection.style.borderRight = 'none';
            propertySection.style.width = '3%';
        });
    } else {
        requestAnimationFrame(function () {
            controlSection.style.removeProperty('width');
            controlSection.style.borderRight = '1px solid #D7D7D7';
            propertySection.style.removeProperty('width');
        });
        setTimeout(function () {
            propertySection.classList.remove('panel-hidden');
        }, 300);
    }
    resizeManualTrigger = true;
    setTimeout(function () {
        window.dispatchEvent(new Event('resize'));
    }, 300);
    resizeManualTrigger = false;
    isPropertyPanelOpen = !isPropertyPanelOpen;
    });
}
// Initialize the notification system when the page is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initializeNotificationSystem);
} else {
    initializeNotificationSystem();
}