## Mapping

This is the mapping between the Workflow and Run portions of the ARC Scaffold and ARC RO-Crate representations.

### ARC Run

| ARC Scaffold | schema term | Explanation |
|----------|-------------|-------------|
|[Run file](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#run-file)|[Dataset](https://schema.org/Dataset)||
|-|@id|Path of the Run folder|
|-|additionalType|for distinction from other Datasets|
|Run Identifier|identifier||
|Run Title|name||
|Run Description|description||
|[Annotation Tables](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#annotation-table-sheets) + CWL Workflow description + YML Parameter Reference|about|same as mentions. <br>See "WorkflowInvocation" for details|
|[Annotation Tables](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#annotation-table-sheets) + CWL Workflow description + YML Parameter Reference|mentions|same as about. <br>See "WorkflowInvocation" for details|
|[RUN PERFORMERS](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#run-performers)|creator|People objects defined in the RUN PERFORMERS section of the isa.run.xlsx file|
|[Data Objects](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#run-performers)|hasPart|Colletion of all data entities defined in the Annotation Tables of the isa.run.xlsx file|
|Run Technology Type|measurementMethod||
|Run Technology Platform|measurementTechnique||
|Run Measurement Type|variableMeasured||
|[Comments](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#attention)|comment||
|Run File Name|url||
|-|hasPart|From the ARC file system|

----------

### ARC Workflow

| ARC Scaffold | schema term | Explanation |
|----------------------------|-------------------|----------------------------------|
|[Workflow file](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#workflow-file)|[Dataset](https://schema.org/Dataset)|
|-|@id|Path of the Workflow folder|
|-|additionalType|for distinction from other Datasets|
|Workflow Identifier|identifier||
|Workflow Title|name||
|Workflow Description|description||
|-|mainEntity|The `workflow.cwl` file|
|[WORKFLOW CONTACTS](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#workflow-contacts)|creator|People objects defined in the WORKFLOW CONTACTS section of the isa.workflow.xlsx file|
|-|hasPart|From the ARC file system|
|comments|comment||
----------

## Workflow Protocol

| ARC Scaffold | schema term | Explanation |
|----------------------------|-------------------|----------------------------------|
|run.cwl or ([Workflow file](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#workflow-file) + workflow.cwl)|[File](https://schema.org/MediaObject),[SoftwareSourceCode](https://schema.org/SoftwareSourceCode),[ComputationalWorkflow](https://bioschemas.org/types/ComputationalWorkflow/1.0-RELEASE),[LabProtocol](https://bioschemas.org/types/LabProtocol/0.5-DRAFT)|
|-|@id|Path of the `workflow.cwl` or `run.cwl` file.|
|-|additionalType| "WorkflowProtocol"|
|Workflow Identifier|name||
|Workflow Title|name||
|Workflow Description|description||
| inputs | input | From the `workflow.cwl` or `run.cwl` file. |
| outputs | output | From the `workflow.cwl` or `run.cwl` file.  |
|protocolType|intendedUse||
|Components|computationalTool|Component entities from the Annotation Tables in the `isa.workflow.xlsx`.|
|Workflow URI|url||
|Workflow Version |version||
|Workflow Type|programmingLanguage||
|-|dateCreated|From the current time during export|
|-|license| From the `LICENSE` file in the ARC root|
|[WORKFLOW CONTACTS](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#workflow-contacts)|creators|People objects defined in the WORKFLOW CONTACTS section of the isa.workflow.xlsx file|
|-|sdPublisher|Sets DataPlant as publisher|
---------------

## Workflow Invocation

| ARC Scaffold | schema term | Explanation |
|----------------------------|-------------------|----------------------------------|
|[Run file](https://github.com/nfdi4plants/ARC-specification/blob/release/ISA-XLSX.md#run-file) + run.cwl + run.yml|[CreateAction](https://schema.org/CreateAction),[LabProcess](https://bioschemas.org/types/LabProcess/0.1-DRAFT)||
|-|@id||
|-|additionalType| "WorkflowInvocation"|
|Annotation Table Name|name|Or run name, if no Annotation Table exists|
|Annotation Table "Input [Data]" + run.yml inputs|object||
|Annotation Table "Output [Data]"|result||
|Workflow from run.yml|instrument||
|Annotation Table Parameters|parameterValue||
|Annotation Table Protocol REF|executesLabProtocol||
|Annotation Table Agent|agent||
|Annotation Table Comment|disambiguatingDescription||
