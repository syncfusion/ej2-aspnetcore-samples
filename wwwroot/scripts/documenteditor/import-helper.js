﻿//Documentloader Implementation starts    
function loadDefault(defaultDocument) {
    documenteditor.open(JSON.stringify(defaultDocument));
}

function loadFile(path) {
    var baseUrl = window.baseurl + 'api/documenteditor/import';
    var httpRequest = new XMLHttpRequest();
    httpRequest.open('POST', baseUrl, true);
    var waitingPopUp = document.getElementById('waiting-popup');
    var inActiveDiv = document.getElementById('popup-overlay');
    documenteditor.isReadOnly = true;
    waitingPopUp.style.display = 'block';
    inActiveDiv.style.display = 'block';
    httpRequest.onreadystatechange = function () {
        if (httpRequest.readyState === 4) {
            if (httpRequest.status === 200 || httpRequest.status === 304) {
                documenteditor.open(httpRequest.responseText);
                documenteditor.isReadOnly = false;
                waitingPopUp.style.display = 'none';
                inActiveDiv.style.display = 'none';
            }
            else {
                waitingPopUp.style.display = 'none';
                inActiveDiv.style.display = 'none';
                documenteditor.isReadOnly = false;
                console.error(httpRequest.response);
            }
        }
    };

    var formData = new FormData();
    formData.append('files', path);
    documenteditor.documentName = path.name.substr(0, path.name.lastIndexOf('.'));
    httpRequest.send(formData);
}

function initComponentAndWireEvent(isRtl) {

    initializeTitleBar(true, isRtl);
    wireEventsInTitleBar();
}
//Documentloader implementation ends


// Title Bar Sample starts 
var documentTitle;
var documentTitleContentEditor;
var titleBarDiv;
var print;
var openBtn;
var download;
var isPropertiesPaneEnabled;
function initializeTitleBar(isShareNeeded, isRtl) {
    if (!isRtl) {
        downloadText = 'Download';
        downloadToolTip = 'Download this document.';
        printText = 'Print';
        printToolTip = 'Print this document (Ctrl+P).';
        openText = 'Open';
        documentTileText = 'Document Name. Click or tap to rename this document.';
    }
    else {
        downloadText = 'تحميل';
        downloadToolTip = 'تحميل هذا المستند';
        printText = 'طباعه';
        printToolTip = 'طباعه هذا المستند (Ctrl + P)';
        openText = 'فتح';
        documentTileText = 'اسم المستند. انقر أو اضغط لأعاده تسميه هذا المستند';
    }
    documentTitle = ej.base.createElement('label', { id: 'documenteditor_title_name', styles: 'font-weight:400;text-overflow:ellipsis;white-space:pre;overflow:hidden;user-select:none;cursor:text' });
    var iconCss = 'e-de-padding-right';
    var btnFloatStyle = 'float:right;';
    var titleCss = '';
    if (isRtl) {
        iconCss = 'e-de-padding-right-rtl';
        btnFloatStyle = 'float:left;';
        titleCss = 'float:right;';
    }
    documentTitleContentEditor = ej.base.createElement('div', { id: 'documenteditor_title_contentEditor', className: 'single-line', styles: titleCss });
    documentTitleContentEditor.appendChild(documentTitle);
    titleBarDiv.appendChild(documentTitleContentEditor);
    documentTitleContentEditor.setAttribute('title', documentTileText);
    var btnStyles = btnFloatStyle + 'background: transparent;box-shadow:none; font-family: inherit;border-color: transparent;' +
        'border-radius: 2px;color:inherit;font-size:12px;text-transform:capitalize;margin-top:4px;height:28px;font-weight:400';
    print = addButton('e-de-icon-Print ' + iconCss, printText, btnStyles, 'de-print', printToolTip, false);
    openBtn = addButton('e-de-icon-Open ' + iconCss, openText, btnStyles, 'de-open', openText, false);
    var items = [
        { text: 'Microsoft Word (.docx)', id: 'word' },
        { text: 'Syncfusion Document Text (.sfdt)', id: 'sfdt' },
    ];
    download = addButton('e-de-icon-Download ' + iconCss, downloadText, btnStyles, 'documenteditor-share', downloadToolTip, true, items);
    if (!isShareNeeded) {
        download.element.style.display = 'none';
    }
    else {
        openBtn.element.style.display = 'none';
    }
}
function wireEventsInTitleBar() {
    print.element.addEventListener('click', onPrint);
    openBtn.element.addEventListener('click', function (e) {
        if (e.target.id === 'de-open') {
            var fileUpload = document.getElementById('uploadfileButton');
            fileUpload.value = '';
            fileUpload.click();
        }
    });
    documentTitleContentEditor.addEventListener('keydown', function (e) {
        if (e.keyCode === 13) {
            e.preventDefault();
            documentTitleContentEditor.contentEditable = 'false';
            if (documentTitleContentEditor.textContent === '') {
                documentTitleContentEditor.textContent = 'Document1';
            }
        }
    });
    documentTitleContentEditor.addEventListener('blur', function () {
        if (documentTitleContentEditor.textContent === '') {
            documentTitleContentEditor.textContent = 'Document1';
        }
        documentTitleContentEditor.contentEditable = 'false';
        documenteditor.documentName = documentTitle.textContent;
    });
    documentTitleContentEditor.addEventListener('click', function () {
        updateDocumentEditorTitle();
    });
}
function updateDocumentEditorTitle() {
    documentTitleContentEditor.contentEditable = 'true';
    documentTitleContentEditor.focus();
    window.getSelection().selectAllChildren(documentTitleContentEditor);
}
function updateDocumentTitle() {
    if (documenteditor.documentName === '') {
        documenteditor.documentName = 'Untitled';
    }
    documentTitle.textContent = documenteditor.documentName;
}
function onPrint() {
    var documentContainer = document.getElementById("container").ej2_instances[0];
    if (documentContainer.documentEditor !== undefined) {
        documentContainer.documentEditor.print();
    } else {
        documentContainer.print();
    }
}
function onExportClick(args) {
    var value = args.item.id;
    switch (value) {
        case 'word':
            save('Docx');
            break;
        case 'sfdt':
            save('Sfdt');
            break;
    }
}
function save(format) {
    var editor = document.getElementById("container").ej2_instances[0].documentEditor;
    editor.save(editor.documentName === '' ? 'sample' : editor.documentName, format);
}
function setTooltipForPopup() {
    document.getElementById('documenteditor-share-popup').querySelectorAll('li')[0].setAttribute('title', 'Download a copy of this document to your computer as a DOCX file.');
    document.getElementById('documenteditor-share-popup').querySelectorAll('li')[1].setAttribute('title', 'Download a copy of this document to your computer as an SFDT file.');
}
function addButton(iconClass, btnText, styles, id, tooltipText, isDropDown, items) {
    var button = ej.base.createElement('button', { id: id, styles: styles });
    titleBarDiv.appendChild(button);
    button.setAttribute('title', tooltipText);
    if (isDropDown) {
        var dropButton = new ej.splitbuttons.DropDownButton({ select: onExportClick, items: items, iconCss: iconClass, cssClass: 'e-caret-hide', content: btnText, open: function () { setTooltipForPopup(); } }, button);
        return dropButton;
    }
    else {
        var ejButton = new ej.buttons.Button({ iconCss: iconClass, content: btnText }, button);
        return ejButton;
    }
}

// Title Bar Implementation Ends 

//StatusBar implemenatation starts
var startPage = 1;
var statusBarDiv;
var pageNumberLabel;
var editablePageNumber;
var pageCount;
var zoom;
var editorPageCount;
function initializeStatusBar() {
    var label = ej.base.createElement('label', { styles: 'margin-top: 6px;margin-right: 2px' });
    label.textContent = 'Page ';
    statusBarDiv.appendChild(label);
    pageNumberLabel = ej.base.createElement('label', { id: 'documenteditor_page_no', styles: 'text-transform:capitalize;white-space:pre;overflow:hidden;user-select:none;cursor:text;height:17px;max-width:150px' });
    editablePageNumber = ej.base.createElement('div', { id: 'editablePageNumber', styles: 'border: 1px solid #F1F1F1;display: inline-flex;height: 17px;padding: 0px 4px;', className: 'single-line e-de-pagenumber-text' });
    editablePageNumber.appendChild(pageNumberLabel);
    updatePageNumber();
    statusBarDiv.appendChild(editablePageNumber);
    editablePageNumber.setAttribute('title', 'The current page number in the document. Click or tap to navigate specific page.');
    var label1 = ej.base.createElement('label', { styles: 'margin-left:2px;letter-spacing: 1.05px;' });
    label1.textContent = 'of';
    statusBarDiv.appendChild(label1);
    pageCount = ej.base.createElement('label', { id: 'documenteditor_pagecount', styles: 'margin-left:6px;letter-spacing: 1.05px;' });
    statusBarDiv.appendChild(pageCount);
    updatePageCount();
    var zoomBtn = ej.base.createElement('button', {
        id: 'documenteditor-zoom',
        className: 'e-de-statusbar-zoom'
    });
    statusBarDiv.appendChild(zoomBtn);
    zoomBtn.setAttribute('title', 'Zoom level. Click or tap to open the Zoom options.');
    var items = [
        {
            text: '200%',
        },
        {
            text: '175%',
        },
        {
            text: '150%',
        },
        {
            text: '125%',
        },
        {
            text: '100%',
        },
        {
            text: '75%',
        },
        {
            text: '50%',
        },
        {
            text: '25%',
        },
        {
            separator: true
        },
        {
            text: 'Fit one page'
        },
        {
            text: 'Fit page width',
        },
    ];
    zoom = new ej.splitbuttons.DropDownButton({ content: '100%', items: items, select: onZoom }, zoomBtn);
}
function onZoom(args) {
    setZoomValue(args.item.text);
    updateZoomContent();
}
function updateZoomContent() {
    zoom.content = Math.round(documenteditor.zoomFactor * 100) + '%';
}
function setZoomValue(text) {
    if (text.match('Fit one page')) {
        documenteditor.fitPage('FitOnePage');
    }
    else if (text.match('Fit page width')) {
        documenteditor.fitPage('FitPageWidth');
    }
    else {
        documenteditor.zoomFactor = parseInt(text, 0) / 100;
    }
}
function updatePageCount() {
    editorPageCount = documenteditor.pageCount;
    pageCount.textContent = editorPageCount.toString();
}
function updatePageNumber() {
    startPage = startPage === undefined ? documenteditor.selection.startPage : startPage;
    pageNumberLabel.textContent = startPage.toString();
}
function updatePageNumberOnViewChange(args) {
    if (documenteditor.selection &&
        documenteditor.selection.startPage >= args.startPage && documenteditor.selection.startPage <= args.endPage) {
        startPage = documenteditor.selection.startPage;
    }
    else {
        startPage = args.startPage;
    }
    updatePageNumber();
}
function wireEventsInStatusbar() {
    editablePageNumber.addEventListener('keydown', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            var pageNumber = parseInt(editablePageNumber.textContent, 0);
            if (pageNumber > editorPageCount) {
                updatePageNumber();
            }
            else {
                documenteditor.scrollToPage(parseInt(editablePageNumber.textContent, 0));
            }
            editablePageNumber.contentEditable = 'false';
            if (editablePageNumber.textContent === '') {
                updatePageNumber();
            }
        }
        if (e.which > 64) {
            e.preventDefault();
        }
    });
    editablePageNumber.addEventListener('blur', function () {
        if (editablePageNumber.textContent === '' || parseInt(editablePageNumber.textContent, 0) > editorPageCount) {
            updatePageNumber();
        }
        editablePageNumber.contentEditable = 'false';
    });
    editablePageNumber.addEventListener('click', function () {
        updateDocumentEditorPageNumber();
    });
}
function updateDocumentEditorPageNumber() {
    editablePageNumber.contentEditable = 'true';
    editablePageNumber.focus();
    window.getSelection().selectAllChildren(editablePageNumber);
}

//StatusBar implemenatation ends

