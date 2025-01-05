| Property | Required | Cardinality | Expected Type | Description | Source Profile |
|----------|----------|-------------|---------------|-------------|----------------|
| <h4>Required Properties</h4> | | | | | |
| **`conformsTo`** | Required | MANY | [IRI](https://datatracker.ietf.org/doc/html/rfc3987#section-2) | Array MUST reference a CreativeWork entity with an @id URI that is consistent with the versioned Permalink of this document, and SHOULD also reference versioned permalinks for Process Run Crate and Workflow RO-Crate. | https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/ |
| **`@context`** | Required | ONE | [schema.org/URL](https://schema.org/URL) | Used to provide the context (namespaces) for the JSON-LD file. This ensures compatibility with Workflow Run Crate standards. | https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/ |
| **`@type`** | Required | 2 | [workflow-run-crate/WorkflowRun](https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/)<br>AND [workflow-run-crate/ProcessRun](https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate) | Defines the types of the Workflow Run and Process Run entities as per Workflow Run Crate standards. | **Workflow Run Crate** |
| **`@id`** | Required | ONE | [IRI](https://datatracker.ietf.org/doc/html/rfc3987#section-2) | Unique identifier for the resource described in JSON-LD. | https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/ |
| **`creator`** | Required | MANY | [schema.org/Organization](https://schema.org/Organization)<br>OR [schema.org/Person](https://schema.org/Person) | Defines the entity that created the Workflow Run. | https://schema.org/CreativeWork |
| **`dateCreated`** | Required | ONE | [schema.org/Date](https://schema.org/Date)<br>OR [schema.org/DateTime](https://schema.org/DateTime) | The date and time when the Workflow Run was created. | https://schema.org/dateCreated |
| **`hasPart`** | Required | MANY | [workflow-run-crate/ProcessRun](https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate) | Defines the Process Runs that are part of the Workflow Run. | https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/ |
| **`name`** | Required | ONE | [schema.org/Text](https://schema.org/Text) | The name of the Workflow Run. | https://schema.org/name |
| **`status`** | Required | ONE | [schema.org/DefinedTerm](https://schema.org/DefinedTerm) | The status of the Workflow Run (e.g., 'completed', 'in progress'). | https://schema.org/definedTerm |
| <h4>Recommended Properties</h4> | | | | | |
| **`description`** | Recommended | ONE | [schema.org/Text](https://schema.org/Text) | A description of the Workflow Run. | https://schema.org/description |
| **`keywords`** | Recommended | MANY | [schema.org/Text](https://schema.org/Text) | Keywords associated with the Workflow Run for search and categorization. | https://schema.org/keywords |
| **`publisher`** | Recommended | MANY | [schema.org/Organization](https://schema.org/Organization)<br>OR [schema.org/Person](https://schema.org/Person) | The entity that published the Workflow Run. | https://schema.org/publisher |
| **`license`** | Recommended | ONE | [schema.org/URL](https://schema.org/URL) | The license under which the Workflow Run is made available. | https://schema.org/license |
| <h4>Optional Properties</h4> | | | | | |
| **`dateModified`** | Optional | ONE | [schema.org/Date](https://schema.org/Date)<br>OR [schema.org/DateTime](https://schema.org/DateTime) | The date and time when the Workflow Run was last modified. | https://schema.org/dateModified |
| **`image`** | Optional | ANY | [schema.org/ImageObject](https://schema.org/ImageObject)<br>OR [schema.org/URL](https://schema.org/URL) | An image associated with the Workflow Run. | https://schema.org/image |
| **`citation`** | Optional | MANY | [schema.org/CreativeWork](https://schema.org/CreativeWork)<br>OR [schema.org/Text](https://schema.org/Text) | A citation related to the Workflow Run. | https://schema.org/citation |
