module WorkflowInvocation
open Domain

let requiredProfileProperties = [
    ProfileRow.create("@id",                  Required, ONE,          [   (IRI, END)], 
                                                                          """A unique identifier for the execution, e.g. "urn:uuid:50ec5c76-1f7a-4130-8ef6-846756b228c1", "#f99a8e6c". MAY be an absolute URI, e.g. http://example.com/runs/846756b228c1. The use of randomly generated UUIDs (type 4) is RECOMMENDED. SHOULD be listed under mentions of the root data entity.""", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("@type",                Required, SPECIFIC 2,   [   (Schema.CreateAction, AND)
                                                                          (BioSchemas.LabProcess, END)], 
                                                                          "MUST be LabProcess and CreateAction to indicate that this tool created the result data entities", 
                                                                          "https://github.com/nfdi4plants/arc-wr-ro-crate-profile/blob/release/profile/arc_wr_ro_crate.md")
    ProfileRow.create("additionalType",       Required, ONE,          [   (Schema.Text, OR)
                                                                          (Schema.URL, END)
                                                                      ], 
                                                                          "MUST be 'Workflow Invocation' or ontology term to identify it as a Workflow Invocation", 
                                                                          "**THIS PROFILE**")
    ProfileRow.create("instrument",           Required, MANY,         [   (Schema.SoftwareApplication, OR)
                                                                          (BioSchemas.ComputationalWorkflow, END)], 
                                                                          "Identifier of the executed tool or workflow in case of a Workflow RO-Crate.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate; https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate")
    ProfileRow.create("agent",                Required, ONE,          [   (Schema.Organization, OR)
                                                                          (Schema.Person, END)], 
                                                                          "Identifier of a Person or Organization contextual entity that started/executed this tool.", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
// Expected types of result and object come from https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate
    ProfileRow.create("result",               Required, MANY,         [   (Schema.MediaObject, OR)
                                                                          (Schema.Dataset, OR)
                                                                          (Schema.Collection, OR)
                                                                          (Schema.CreativeWork, OR)
                                                                          (Schema.PropertyValue, END)], 
                                                                          "The identifier of one or more entities that were created or modified by this action, e.g. output files. Entities referenced by an action�s object or result SHOULD be of type File (an RO-Crate alias for MediaObject) for files, Dataset for directories and Collection for multi-file datasets, but MAY be a CreativeWork for other types of data (e.g. an online database); they MAY be of type PropertyValue to capture numbers/strings that are not stored as files.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate, https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("object",               Required, MANY,         [   (Schema.MediaObject, OR)
                                                                          (Schema.Dataset, OR)
                                                                          (Schema.Collection, OR)
                                                                          (Schema.CreativeWork, OR)
                                                                          (Schema.PropertyValue, END)], 
                                                                          "The identifier of one or more entities of the RO-Crate that were consumed by this action, e.g. input files or reference datasets. Entities referenced by an action�s object or result SHOULD be of type File (an RO-Crate alias for MediaObject) for files, Dataset for directories and Collection for multi-file datasets, but MAY be a CreativeWork for other types of data (e.g. an online database); they MAY be of type PropertyValue to capture numbers/strings that are not stored as files.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate, https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("name",                 Required, ONE,          [   (Schema.Text, END)], 
                                                                          "Short human-readable description of the execution.", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
]
let optionalProfileProperties = [
// The following two properties are from LabProcess
    ProfileRow.create("executesLabProtocol",  Optional, ONE,          [   (BioSchemas.LabProtocol, END)], 
                                                                          "The protocol executed. In this case, it refers to the multitype entity of the ARC CWL Workflow Profile with File, SoftwareSourceCode, ComputationalWorkflow and LabProtocol", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("parameterValue",       Optional, ONE,          [   (Schema.PropertyValue, END)], 
                                                                          "A parameter value of the workflow process, usually a key-value pair using ontology terms", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    // Recommended -> Optional
    ProfileRow.create("description",          Optional, ONE,          [   (Schema.Text, OR)
                                                                          (Schema.TextObject, END)], 
                                                                          "Details of the execution, for instance command line arguments or settings. This field is for information only, no particular structure is to be assumed.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    // endTime is a property of Action, but specifically mentioned as optional in the LabProcess schema
    ProfileRow.create("endTime",              Optional, ONE,          [   (Schema.DateTime, OR)
                                                                          (Schema.Time, END)], 
                                                                          "The endTime of something. For a reserved event or service (e.g. FoodEstablishmentReservation), the time that it is expected to end. For actions that span a period of time, when the action was performed. E.g. John wrote a book from January to December. For media, including audio and video, it's the time offset of the end of a clip within a larger file.", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("disambiguatingDescription", Optional, ONE,     [   (Schema.Text, END)], 
                                                                          "A sub property of description. A short description of the item used to disambiguate from other, similar items. Information from other properties (in particular, name) may be necessary for the description to be useful for disambiguation.", 
                                                                          "https://schema.org/Thing")
]

let profile = Profile.create(
    name = "WorkflowInvocation",
    required = requiredProfileProperties,
    //recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)