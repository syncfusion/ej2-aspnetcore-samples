    var currentPageBox
    var matchCase = false;
	var filename;
    var selectedFormField;
    window.onload = function () {
        currentPageBox = document.getElementById('currentPage');
        currentPageBox.value = '1';
        document.getElementById('fileUpload').addEventListener('change', readFile, false);
        currentPageBox.addEventListener('keypress', () => {
            var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
            var currentPage = document.getElementById('currentPage');
            if ((event.which < 48 || event.which > 57) && event.which !== 8 && event.which !== 13) {
                event.preventDefault();
                return false;
            } else {
                var currentPageNumber = parseInt((currentPage).value);
                if (event.which === 13) {
                    if (currentPageNumber > 0 && currentPageNumber <= pdfViewer.pageCount) {
                        pdfViewer.navigation.goToPage(currentPageNumber);
                    } else {
                        (currentPage).value = pdfViewer.currentPageNumber.toString();
                    }
                }
                return true;
            }
        });
    }

     function contentTemplate() {
       return `<ejs-menu id="menu" select="select(event)" items='menuItems'></ejs-menu> `;
     }
    function select(args) {
      var viewer = document.getElementById('pdfviewer').ej2_instances[0];
      var stampId = args.element.id;
      var stampText = args.element.innerText;
      if(stampId === 'Dynamic' && stampText != null) {
        if(stampText === 'Revised')
        {
          viewer.annotation.setAnnotationMode("Stamp", "Revised");
        }
        else if(stampText == "Reviewed")
        {
                viewer.annotation.setAnnotationMode("Stamp", "Reviewed");
        }
        else if(stampText == "Received")
        {
                viewer.annotation.setAnnotationMode("Stamp", "Received");
        }
        else if(stampText == "Confidential")
        {
                viewer.annotation.setAnnotationMode("Stamp", "Confidential");
        }
        else if(stampText == "Approved")
        {
                viewer.annotation.setAnnotationMode("Stamp", "Approved");
        }
        else if(stampText == "Not Approved")
        {
                viewer.annotation.setAnnotationMode("Stamp", "NotApproved");
        }
      }
      if(stampId === 'Sign Here' && stampText != null) {
        if(stampText === 'Witness')
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, "Witness");
        }
        else if(stampText == "Initial Here")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, "InitialHere");
        }
        else if(stampText == "Sign Here")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, "SignHere");
        }
        else if(stampText == "Accepted")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, "Accepted");
        }
        else if(stampText == "Rejected")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, "Rejected");
        }
      }
      if(stampId === 'Standard Business' && stampText != null) {
        if(stampText === 'Approved')
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Approved");
        }
        else if(stampText == "Not Approved")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "NotApproved");
        }
        else if(stampText == "Draft")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Draft");
        }
        else if(stampText == "Final")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Final");
        }
        else if(stampText == "Completed")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Completed");
        }
        else if(stampText == "Confidential")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Confidential");
        }
        else if(stampText == "For Public Release")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "ForPublicRelease");
        }
        else if(stampText == "Not For Public Release")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "NotForPublicRelease");
        }
        else if(stampText == "For Comment")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "ForComment");
        }
        else if(stampText == "Void")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "Void");
        }
        else if(stampText == "Preliminary Results")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "PreliminaryResults");
            }
        else if(stampText == "Information Only")
        {
                viewer.annotation.setAnnotationMode("Stamp", undefined, undefined, "InformationOnly");
        }
      }
   
  }
  function onFormFieldSelected(evt) {
    selectedFormField = evt.field;
  }
  
  function onFormFieldUnSelected(evt) {
    //selectedFormField = null;
  }
    function openPage() {
        document.getElementById('fileUpload').click();
    }
    function readFile(evt) {
        var upoadedFiles = evt.target.files;
        var uploadedFile = upoadedFiles[0];
		filename = upoadedFiles[0].name;
        var reader = new FileReader();
        reader.readAsDataURL(uploadedFile);
        reader.onload = function () {
            var obj = document.getElementById('pdfviewer').ej2_instances[0];
            var uploadedFileUrl = pdfViewerresult;
            obj.load(uploadedFileUrl, null);
			obj.fileName = filename;
            currentPageBox = document.getElementById('currentPage');
            currentPageBox.value = '1';
            var pageCount = document.getElementById('totalPage');
            pageCount.textContent = 'of ' + obj.pageCount;
        }
    }
    function pageChanged() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
       document.getElementById('currentPage').value = pdfViewer.currentPageNumber;
        updatePageNavigation();
    }
    function onCurrentPageBoxKeypress(event) {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        var currentPageBox = document.getElementById('currentPage');
        if ((event.which < 48 || event.which > 57) && event.which !== 8 && event.which !== 13) {
            event.preventDefault();
            return false;
        }
        else {
            var currentPageNumber = parseInt(currentPageBox.value);
            if (event.which === 13) {
                if (currentPageNumber > 0 && currentPageNumber <= viewer.pageCount) {
                    pdfViewer.navigation.goToPage(currentPageNumber);
                }
                else {
                    currentPageBox.value = viewer.currentPageNumber.toString();
                }
            }
            return true;
        }
    }

    function currentPageClicked() {
        var currentPage = document.getElementById('currentPage');
        (currentPage).select();
    }
    function documentLoaded() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        var pageCount = document.getElementById('totalPage');
        pageCount.textContent = 'of ' + pdfViewer.pageCount;
        updatePageNavigation();
    }
    function updatePageNavigation() {
        var toolbarObj = document.getElementById('topToolbar').ej2_instances[0];
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        if (pdfViewer.currentPageNumber === 1) {
            toolbarObj.enableItems(document.getElementById('previousPage'), false);
            toolbarObj.enableItems(document.getElementById('nextPage'), true);
        } else if (pdfViewer.currentPageNumber === pdfViewer.pageCount) {
            toolbarObj.enableItems(document.getElementById('previousPage'), true);
            toolbarObj.enableItems(document.getElementById('nextPage'), false);
        } else {
            toolbarObj.enableItems(document.getElementById('previousPage'), true);
            toolbarObj.enableItems(document.getElementById('nextPage'), true);
        }
    }
    function previousClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.navigation.goToPreviousPage();
    }
    function nextClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.navigation.goToNextPage();
    }
    function textSelection() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.interactionMode = 'TextSelection';
    pdfViewer.enableTextSelection = true;

    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement?.style.display === 'block') {
      editAnnotationToolbarElement.style.display = 'none';
    }

    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement?.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement?.style.display === 'block') {
      signatureToolbarElement.style.display = 'none';
    }

    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement?.style.display === 'block') {
      formFieldToolbarElement.style.display = 'none';
      pdfViewer.designerMode = false;
    }
  }

  function panMode() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.interactionMode = 'Pan';
    pdfViewer.enablePanMode = true;

    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement?.style.display === 'block') {
      editAnnotationToolbarElement.style.display = 'none';
    }

    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement?.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement?.style.display === 'block') {
      signatureToolbarElement.style.display = 'none';
    }

    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement?.style.display === 'block') {
      formFieldToolbarElement.style.display = 'none';
      pdfViewer.designerMode = false;
    }
  }
    function printClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.print.print();
    }
    function downloadClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.download();
    }
    function pageFitClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.magnification.fitToPage();
    }
    function zoomInClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.magnification.zoomIn();
    }
    function zoomOutClicked() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        pdfViewer.magnification.zoomOut();
    }
  
  function openEditAnnotation() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement !== null && textSearchToolbarElement.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement !== null && signatureToolbarElement.style.display === 'block') {
      signatureToolbarElement.style.display = 'none';
    }

    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement !== null && formFieldToolbarElement.style.display === 'block') {
      formFieldToolbarElement.style.display = 'none';
      pdfViewer.designerMode = false;
    }
    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement !== null) {
      if (editAnnotationToolbarElement.style.display === 'block') {
        editAnnotationToolbarElement.style.display = 'none';
      } else {
        editAnnotationToolbarElement.style.display = 'block';
      }
    }

  }
  function addEditFormFields() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement !== null) {
      if (formFieldToolbarElement.style.display === 'block') {
        formFieldToolbarElement.style.display = 'none';
        pdfViewer.designerMode = false;
      } else {
        formFieldToolbarElement.style.display = 'block';
        pdfViewer.designerMode = true;
      }
    }

    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement !== null && editAnnotationToolbarElement.style.display === 'block') {
      editAnnotationToolbarElement.style.display = 'none';
    }

    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement !== null && textSearchToolbarElement.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement !== null && signatureToolbarElement.style.display === 'block') {
      signatureToolbarElement.style.display = 'none';
    }
  }


  function onAnnotationAdd() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.isAnnotationToolbarVisible = false;
  }
  function highlight() {
     var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Highlight');
  }
  function underLine() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Underline');
  }

  function strikeThrough() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Strikethrough');
  }

   function addLine() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Line');
  }

  function addArrow() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Arrow')
  }

  function addRectangle() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Rectangle');
  }

  function addCircle() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Circle');
  }

  function addPoligon() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Polygon');
  }

  function distance() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Distance');
  }

  function perimeter() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Perimeter');
  }

  function area() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Area');
  }

  function radius() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Radius');
  }

  function volume() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('Volume');
  }

  function freeText() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    pdfViewer.annotation.setAnnotationMode('FreeText');
  }
  function deleteFormField(){
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if (selectedFormField !== null) {
      pdfViewer.formDesignerModule.deleteFormField(selectedFormField);
    }
  }
    function addSign() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    const element = document.querySelector('.e-dropdown-popup');
    if (element !== null) {
      if ('formField_signature') {
        const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
        if (editAnnotationToolbarElement !== null && editAnnotationToolbarElement.style.display === 'block') {
          editAnnotationToolbarElement.style.display = 'none';
        }

        element.style.left = '605px';
        element.style.top = '174px';
      } else {
        element.style.left = '790px';
        element.style.top = '137px';
      }
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement !== null) {
      if (signatureToolbarElement.style.display === 'block') {
        signatureToolbarElement.style.display = 'none';
      } else {
        signatureToolbarElement.style.display = 'block';
      }
    }

    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement !== null && textSearchToolbarElement.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
    }

  }
    function addSign1() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
      if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
      }
     const element = document.querySelector('.e-dropdown-popup');
      if (element !== null) {
      if ('signature') {
        const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
        if (editAnnotationToolbarElement !== null && editAnnotationToolbarElement.style.display === 'block') {
          editAnnotationToolbarElement.style.display = 'block';
        }

        element.style.left = '605px';
        element.style.top = '174px';
      } else {
        element.style.left = '790px';
        element.style.top = '137px';
      }
      }

     const signatureToolbarElement = document.getElementById('SignatureToolbar');
      if (signatureToolbarElement !== null) {
      if (signatureToolbarElement.style.display === 'block') {
        signatureToolbarElement.style.display = 'none';
      } else {
        signatureToolbarElement.style.display = 'block';
      }
      }

     const textSearchToolbarElement = document.getElementById('textSearchToolbar');
      if (textSearchToolbarElement !== null && textSearchToolbarElement.style.display === 'block') {
      textSearchToolbarElement.style.display = 'none';
      }

    }
  function findText() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if(pdfViewer.tool == 'Ink'){
      pdfViewer.annotation.setAnnotationMode('Ink');
    }
    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement !== null && editAnnotationToolbarElement.style.display === 'block') {
      editAnnotationToolbarElement.style.display = 'none';
    }

    const textSearchToolbarElement = document.getElementById('textSearchToolbar');
    if (textSearchToolbarElement !== null) {
      if (textSearchToolbarElement.style.display === 'block') {
        textSearchToolbarElement.style.display = 'none';
      } else {
        textSearchToolbarElement.style.display = 'block';
      }
    }

    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement !== null && formFieldToolbarElement.style.display === 'block') {
      formFieldToolbarElement.style.display = 'none';
      pdfViewer.designerMode = false;
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement !== null) {
      if (signatureToolbarElement.style.display === 'block') {
        signatureToolbarElement.style.display = 'none';
      } else {
        signatureToolbarElement.style.display = 'none';
      }
    }
  }
  function searchInputKeypressed(event){
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if (event.key === 'Enter') {
      initiateTextSearch();
    }
  }

 var searchText = '';
 var prevMatchCase = false;
 var matchCase = false;

function initiateTextSearch() {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    var textsearchPrevElement = document.getElementById('container_prev_occurrence');
    var textsearchNextElement = document.getElementById('container_next_occurrence');
    var textsearchcloseElement = document.getElementById('container_close_search_box-icon');
    var textsearchElement = document.getElementById('container_search_box-icon');

    if (textsearchPrevElement && textsearchNextElement && textsearchcloseElement && textsearchElement) {
        textsearchPrevElement.disabled = false;
        textsearchNextElement.disabled = false;
        textsearchcloseElement.style.display = 'block';
        textsearchElement.style.display = 'none';

        var currentSearchText = document.getElementById('container_search_input').value;

        if (searchText !== (document.getElementById('container_search_input')).value || prevMatchCase !== matchCase) {
        pdfViewer.textSearchModule.cancelTextSearch();
        searchText = (document.getElementById('container_search_input')).value;
        pdfViewer.textSearchModule.searchText(searchText, matchCase);
        prevMatchCase = matchCase;
      } else {
            nextTextSearch();
        }
    }
}

  function clearTextSearch(){
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    const textsearchcloseElement = document.getElementById('container_close_search_box-icon') ;
    const textsearchElement = document.getElementById('container_search_box-icon') ;
    textsearchcloseElement.style.display = 'none';
    textsearchElement.style.display = 'block';
    pdfViewer.textSearchModule.cancelTextSearch();
    const searchTextElement = document.getElementById('container_search_input') ;
    searchTextElement.value = '';
  }

  function previousTextSearch() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.textSearchModule.searchPrevious();
  }

  function nextTextSearch() {
      var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.textSearchModule.searchNext();
  }
   function checkBoxChanged(event) {
    const target = event.target;
    if (target.checked) {
      const matchcaseElement = document.getElementById('container_match_case');
      if (matchcaseElement) {
        matchcaseElement.checked = true;
      }
      matchCase = true;
      const checkboxSpanElement = document.getElementById('checkboxSpan');
      if (checkboxSpanElement) {
        checkboxSpanElement.classList.add('e-check');
      }
    } else {
      matchCase = false;
      const checkboxSpanElement = document.getElementById('checkboxSpan');
      if (checkboxSpanElement) {
        checkboxSpanElement.classList.remove('e-check');
      }
    }
  }
  function ink() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.annotation.setAnnotationMode('Ink');
  }

  function textBox() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('Textbox');
  }

  function passWord() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('Password');
  }

  function checkBox() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('CheckBox');
  }

  function radioButton() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('RadioButton');
  }

  function dropDown() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('DropDown');
  }

  function listBox() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    pdfViewer.formDesignerModule.setFormFieldMode('ListBox');
  }

  function deleteFormField() {
       var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    if (selectedFormField !== null) {
      pdfViewer.formDesignerModule.deleteFormField(selectedFormField);
    }
  }

   function onSignatureClick(event) {
    var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
    const editAnnotationToolbarElement = document.getElementById('editAnnotationToolbar');
    if (editAnnotationToolbarElement?.style.display === 'block') {
      if (event) {
        if (event.innerText === 'ADD SIGNATURE') {
          pdfViewer.annotationModule.setAnnotationMode('HandWrittenSignature');
        } else if (event.innerText === 'ADD INITIAL') {
          pdfViewer.annotationModule.setAnnotationMode('Initial');
        }
      }
    }

    const formFieldToolbarElement = document.getElementById('formFieldToolbar');
    if (formFieldToolbarElement?.style.display === 'block') {
      if (event) {
        if (event.innerText === 'ADD SIGNATURE') {
          pdfViewer.formDesignerModule.setFormFieldMode('SignatureField');
        } else if (event.innerText === 'ADD INITIAL') {
          pdfViewer.formDesignerModule.setFormFieldMode('InitialField');
        }
      }
    }

    const signatureToolbarElement = document.getElementById('SignatureToolbar');
    if (signatureToolbarElement?.style.display === 'block') {
      signatureToolbarElement.style.display = 'none';
    }
  }