#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [
    // properties from https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/
    ProfileRow.create("conformsTo",         Required, MANY,   [   (IRI, END)], 
                                                                    "Array MUST reference a CreativeWork entity with an @id URI that is consistent with the versioned Permalink of this document, and SHOULD also reference versioned permalinks for Process Run Crate and Workflow RO-Crate.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/")
    // properties from
    ProfileRow.create("@context",           Required, ONE,          [   (Schema.URL, END)], 
                                                                    "Used to provide the context (namespaces) for the JSON-LD file. This ensures compatibility with Workflow Run Crate standards.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/")
    ProfileRow.create("@type",              Required, SPECIFIC 2,   [   (WorkflowRunProfile.WorkflowRun, AND)
                                                                        (WorkflowRunProfile.ProcessRun, END)
                                                                    ], 
                                                                    "Defines the types of the Workflow Run and Process Run entities as per Workflow Run Crate standards.", 
                                                                    "**Workflow Run Crate**")
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Unique identifier for the resource described in JSON-LD.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/")
    ProfileRow.create("creator",            Required, MANY,         [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "Defines the entity that created the Workflow Run.", 
                                                                    "https://schema.org/CreativeWork")
    ProfileRow.create("dateCreated",        Required, ONE,          [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "The date and time when the Workflow Run was created.", 
                                                                    "https://schema.org/dateCreated")
    ProfileRow.create("hasPart",            Required, MANY,         [   (WorkflowRunProfile.ProcessRun, END)], 
                                                                    "Defines the Process Runs that are part of the Workflow Run.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/")
    ProfileRow.create("name",               Required, ONE,          [   (Schema.Text, END)], 
                                                                    "The name of the Workflow Run.", 
                                                                    "https://schema.org/name")
    ProfileRow.create("status",             Required, ONE,          [   (Schema.DefinedTerm, END)], 
                                                                    "The status of the Workflow Run (e.g., 'completed', 'in progress').", 
                                                                    "https://schema.org/definedTerm")
]

let recommendedProfileRows = [
    // properties from https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/
    ProfileRow.create("description",            Recommended, ONE,   [   (Schema.Text, END)], 
                                                                    "A description of the Workflow Run.", 
                                                                    "https://schema.org/description")
    ProfileRow.create("keywords",               Recommended, MANY,  [   (Schema.Text, END)], 
                                                                    "Keywords associated with the Workflow Run for search and categorization.", 
                                                                    "https://schema.org/keywords")
    ProfileRow.create("publisher",              Recommended, MANY,  [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The entity that published the Workflow Run.", 
                                                                    "https://schema.org/publisher")
    ProfileRow.create("license",                Recommended, ONE,   [   (Schema.URL, END)], 
                                                                    "The license under which the Workflow Run is made available.", 
                                                                    "https://schema.org/license")
]

let optionalProfileRows = [
    ProfileRow.create("dateModified",           Optional, ONE,      [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "The date and time when the Workflow Run was last modified.", 
                                                                    "https://schema.org/dateModified")
    ProfileRow.create("image",                  Optional, ANY,      [   (Schema.ImageObject, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "An image associated with the Workflow Run.", 
                                                                    "https://schema.org/image")
    ProfileRow.create("citation",               Optional, MANY,     [   (Schema.CreativeWork, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "A citation related to the Workflow Run.", 
                                                                    "https://schema.org/citation")
]

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"workflow-run.generated.md"), 
    [
        "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
        "|----------|----------|-------------|---------------|-------------|----------------|"
    ]
    @ ["| <h4>Required Properties</h4> | | | | | |"]
    @ (requiredProfileProperties |> List.map ProfileRow.toTableRow)
    @ ["| <h4>Recommended Properties</h4> | | | | | |"]
    @ (recommendedProfileRows |> List.map ProfileRow.toTableRow)
    @ ["| <h4>Optional Properties</h4> | | | | | |"]
    @ (optionalProfileRows |> List.map ProfileRow.toTableRow)
)