var switcherPopup;
var themeSwitherPopup;
var openedPopup;
var searchPopup;
var settingsPopup;
var prevAction;
var ArrayItem;
var items = [];
var searchInstance;
var headerThemeSwitch = document.getElementById('header-theme-switcher');
var settingElement = ej.base.select('.sb-setting-btn');
var themeList = document.getElementById('themelist');
var themes = ['material3', 'fluent', 'fluent2', 'bootstrap5.3', 'tailwind', 'tailwind3', 'highcontrast', 'fluent2-highcontrast'];
//var themeIndex = { 'material3': 0, 'material3-dark': 1, 'fluent': 2, 'fluent-dark': 3, 'bootstrap5': 4, 'bootstrap5-dark': 5, 'tailwind': 6, 'tailwind-dark': 7, 'material': 8, 'bootstrap4': 9, 'bootstrap': 10, 'bootstrap-dark': 11, 'highcontrast': 12 };
var themeIndex = { 'material3': 0, 'fluent': 1, 'fluent2': 2, 'bootstrap5': 3, 'tailwind3': 4, 'highcontrast': 5, 'fluent2-highcontrast': 6 };
var themeMode_Index = { 'material3': 'Material 3', 'fluent': 'Fluent', 'fluent2': 'Fluent 2', 'bootstrap5': 'Bootstrap 5', 'highcontrast': 'High Contrast', 'fluent2-highcontrast': 'Fluent 2 High Contrast', 'tailwind3': 'Tailwind CSS'  };
var cultureData = { "English": "en", "German - Germany*": "de", "French - Switzerland*": "fr-CH", "Arabic*": "ar", "Chinese - China*":"zh" };
var defaultTheme = 'tailwind3';
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
                        location.href = location.origin + getPathName() + `grid/gridoverview#/` + getThemeName();
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
    listViewData.dataSource = listViewData.dataSource.length != 0 ? controlSampleData[listViewData.dataSource[0].dir.toLowerCase()] : (controlSampleData[location.pathname.split('/').slice(-2)[0]] || controlSampleData.Button);
}

function setTreeData() {
    var treeViewData = ej.base.select('#controlTree').ej2_instances[0];
    treeViewData.fields.dataSource = samplesTreeList;
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
    themeName = themeName === 'bootstrap5.3' ? 'bootstrap5' : themeName;
    var storedURL = localStorage.getItem('PreviousURL');
    if (storedURL != null && storedURL.includes("-dark") && themeName != "highcontrast" && themeName != "fluent2-highcontrast") {
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

function switchTheme(str) {
    if (typeof str === 'string') {
        var themeName = str;
    } else {
        if (str.value) {
            var dropdownMode = document.getElementById("sb-setting-mode").ej2_instances[0];
            if (window.matchMedia("(max-width: 550px)").matches) {
                if (str.value != "highcontrast" && str.value != "fluent2-highcontrast") {
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
    themeName = themeName === 'bootstrap5.3' ? 'bootstrap5' : themeName === 'bootstrap5.3-dark' ? 'bootstrap5-dark' : themeName;
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
        location.href = location.origin + getPathName() + curhref + '#/' + theme;
    }
    window.hashString = location.origin + getPathName() + curhref + '#/' + theme;
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
            ej.base.select('.sb-mobile-prop-pane').appendChild(propPanel);
            ej.base.select('.sb-mobile-setting').classList.remove('sb-hide');
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
        var mobilePropPane = ej.base.select('.sb-mobile-prop-pane .property-section');
        if (mobilePropPane) {
            ej.base.select('#control-content').appendChild(mobilePropPane);
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
    document.addEventListener('click', sbHeaderClick.bind(this, 'closePopup'));
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

function loadTheme(theme) {
    var body = document.body;
    if (body.classList.length > 0) {
        for (var themeItem in themes) {
            body.classList.remove(themes[themeItem]);
        }
    }
    theme = theme == 'bootstrap5' ? 'bootstrap5.3' : theme == 'bootstrap5-dark' ? 'bootstrap5.3-dark' : theme;
    body.classList.add(theme);
    themeList.querySelector('.active').classList.remove('active');
   
    var currentUpdatedTheme = theme.replace("-dark", "");
    if(currentUpdatedTheme != "tailwind")
    {
        currentUpdatedTheme == 'bootstrap5.3' ? themeList.querySelector('#bootstrap5\\.3').classList.add('active') : themeList.querySelector('#' + currentUpdatedTheme).classList.add('active');
    }
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
    searchInstance = elasticlunr.Index.load(window.searchIndex);
    hasher.initialized.add(parseHash);
    hasher.changed.add(parseHash);
    hasher.init();
   /* removing dark or light them options for fluent2-highcontrast themeSwitchDiv*/
    if (theme == 'fluent2-highcontrast') {
        var theamswitchDivDisable = document.getElementById("themeSwitchDiv");
        theamswitchDivDisable.style.display = 'none';
    }

    var mobileThemeModeElement = document.getElementById('themeSwitchMobile');
    var mobileThemeModeDropDownstyle = window.getComputedStyle(mobileThemeModeElement);
    if (mobileThemeModeDropDownstyle.display === "block") {
        var hashValue = window.location.href.split("#/")[1];
        if (hashValue !== 'fluent2-highcontrast' && hashValue !== 'highcontrast') {
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
    if (ej.base.Browser.isDevice) {
        var tempList = ej.base.extend([], window.samplesList);
        var sampleList = [];
        for (var i = 0; i < tempList.length; i++) {
            var temp = tempList[i];
            var data = new ej.data.DataManager(temp.samples);
            temp.samples = data.executeLocal(new ej.data.Query().where('hideOnDevice', 'notEqual', true));
            sampleList = sampleList.concat(temp);
        }
        return sampleList;
    }
    return window.samplesList;
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
        controlSampleData[list[i].directory.toLowerCase()] = getSamples(list[i].samples);
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
        themeName = location.hash.split('/')[1] === 'bootstrap5.3' ? 'bootstrap5' : location.hash.split('/')[1];
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
        location.href = location.origin + location.pathname.split('/').slice(0, count).join('/') + '#/' + theme;
    }
    else {
        if (location.pathname.slice(- 1) === '/') {
            location.href = location.origin + curHashCollection.slice(0, -1);
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
                            location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + arg.data.url.toLowerCase() + '#/' + theme;
                        }
                        else {
                            location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + defaultSample[0].url.toLowerCase() + '#/' + theme;
                        }
                    }
                    else {
                        location.href = location.origin + pathName + arg.data.dir.toLowerCase() + '/' + arg.data.url.toLowerCase() + '#/' + theme;
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
        window.navigateSample();
        isExternalNavigation = defaultTree = false;
        setPropertySectionHeight();
        removeOverlay();
        var mobilePropPane = ej.base.select('.sb-mobile-prop-pane .property-section');
        if (mobilePropPane) {
            ej.base.detach(mobilePropPane);
        }
        var propPanel = ej.base.select('#control-content .property-section');
        if (isMobile) {
            if (propPanel) {
                viewMobilePropPane(); 
                var toggleAnim = new ej.base.Animation({ duration: 500, timingFunction: 'ease' });
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
                ej.base.select('.sb-mobile-setting').classList.remove('sb-hide');
                document.querySelector('.sb-content-tab-header').style.display = 'block';
                ej.base.select('.sb-mobile-prop-pane').appendChild(propPanel);
            } else {
                ej.base.select('.sb-mobile-setting').classList.add('sb-hide');
                document.querySelector('.sb-content-tab-header').style.display = 'none';
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
        })(window, document, 'script', 'dataLayer', 'GTM-W8WD8WN');
    }, 500);
}
function removeOverlay() {
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
    var switchText = localStorage.getItem('ej2-switch') || 'mouse';
    if (ej.base.Browser.isDevice || window.screen.width <= 850) {
        switchText = 'touch';
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

function ScrollToSelected() {
    const selectedDiv = document.querySelector('.sb-left-pane .e-listview .e-list-item.e-active');
    if (selectedDiv) {
        selectedDiv.scrollIntoView({ block: 'center' });
    }
}

//window.onload = function () {
 //   setTimeout(function () {
 //       ScrollToSelected();
 //   }, 500);
//}

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
    if (!currentURL.includes("highcontrast") && !currentURL.includes("fluent2-highcontrast")) {
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
