### Feature description
Clearly and concisely describe the feature.

### Requirement and specification document.
Share the JIRA task which is attached with the requirement and specification document or directly share the document. 
- Even for a small feature, draft a requirement and specification document and attach it in the task.  

### API Review task
Provide task link.

### Output screenshots
Post the output screenshots if an UI is affected or added due to this feature.

### Feature matrix document

Feature matrix document updated against this feature and committed in this [common location] (https://syncfusion.sharepoint.com/sites/EJ2ProductOwners/Shared%20Documents/Forms/AllItems.aspx?viewid=ae81c682%2D3d0f%2D462a%2Db8ec%2D7358748d489d&id=%2Fsites%2FEJ2ProductOwners%2FShared%20Documents%2FGeneral%2FFeature%20Matrix%20%2D%20Documents) . 
* [ ] Yes
* [ ] NO
* [ ] NA

Provide the details about the areas or combinations which have been tested against this code changes.
* [ ]  Tested against feature matrix.

### Feature acceptance criteria (Test-case document)
Draft the test cases in excel and attach it in the MR itself. The automation must be covered based on this positive and worst-case test-cases.   

### Automation details
Mark 'Is Automated' field as (Yes, Manual, Not Applicable) in corresponding JIRA task once the feature is automated. 
* [ ] BUnit, share corresponding MR.
* [ ] E2E or Manual Automation using tester - Make sure all items are automated with priority before release which can be tracked in [automation dashboard](https://syncfusion.atlassian.net/secure/Dashboard.jspa?selectPageId=43396).

### Test bed sample location
Provide the test bed sample location where the code reviewers can review the new feature’s behaviors. 
 
### Feature completion checklist

UX changes got approval if UI is added or modified?
* [ ] Yes. Provide Task link.
* [ ] NO
* [ ] NA

Drafted UG for this feature?
* [ ] Yes, provide MR link.
* [ ] NO, provide task link.
* [ ] NA

 Content team reviewed the UI content changes.
* [ ] Yes. Provide MR or Task link.
* [ ] NO
* [ ] NA

 Is this the common feature which needs to be addressed in the same component or on other components in our platform? 
* [ ]  Yes. If we need to check in other components, tag "needs-attention-coreteam" 
* [ ]  NO

Is there any existing behavior change due to this code change?
* [ ]  Yes. If So, add `breaking-change` label.
* [ ]  NO

### Blazor Checklist
Confirm whether the ensured feature is in both Blazor Server and WASM.
* [ ] Yes
* [ ] NO
* [ ] NA

Do the code changes cause any memory leak and performance issue?
* [ ] Yes
* [ ] NO

## Reviewer Checklist
* [ ]  Reviewed feature matrix document modifications and reviewed developer testing report against the feature matrix reviewed.
* [ ]  Testbed sample ensured.
* [ ]  Coverage report checked.
* [ ]  Ensured the code changes meet the coding standard.
* [ ]  Confirming script changes made in this merge request can't be achieved in C#. 

Created task in Blazor to synchronize if the feature is not available and applicable.
* [ ] NA
* [ ] Yes, task link.
* [ ] NO, share reason.
