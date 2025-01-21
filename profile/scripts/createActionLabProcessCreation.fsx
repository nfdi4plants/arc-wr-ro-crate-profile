#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [
    ProfileRow.create("@id",                  Required, ONE,          [   (IRI, END)], 
                                                                          """A unique identifier for the execution, e.g. "urn:uuid:50ec5c76-1f7a-4130-8ef6-846756b228c1", "#f99a8e6c". MAY be an absolute URI, e.g. http://example.com/runs/846756b228c1. The use of randomly generated UUIDs (type 4) is RECOMMENDED. SHOULD be listed under mentions of the root data entity.""", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("@type",                Required, SPECIFIC 2,   [   (Schema.CreateAction, AND)
                                                                          (BioSchemas.LabProcess, END)], 
                                                                          "MUST be LabProcess and CreateAction to indicate that this tool created the result data entities", 
                                                                          "https://github.com/nfdi4plants/arc-cwl-ro-crate-profile/blob/release/profile/arc_cwl_ro_crate.md")
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
                                                                          "The identifier of one or more entities that were created or modified by this action, e.g. output files. Entities referenced by an action’s object or result SHOULD be of type File (an RO-Crate alias for MediaObject) for files, Dataset for directories and Collection for multi-file datasets, but MAY be a CreativeWork for other types of data (e.g. an online database); they MAY be of type PropertyValue to capture numbers/strings that are not stored as files.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate, https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("object",               Required, MANY,         [   (Schema.MediaObject, OR)
                                                                          (Schema.Dataset, OR)
                                                                          (Schema.Collection, OR)
                                                                          (Schema.CreativeWork, OR)
                                                                          (Schema.PropertyValue, END)], 
                                                                          "The identifier of one or more entities of the RO-Crate that were consumed by this action, e.g. input files or reference datasets. Entities referenced by an action’s object or result SHOULD be of type File (an RO-Crate alias for MediaObject) for files, Dataset for directories and Collection for multi-file datasets, but MAY be a CreativeWork for other types of data (e.g. an online database); they MAY be of type PropertyValue to capture numbers/strings that are not stored as files.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate, https://bioschemas.org/types/LabProcess/0.1-DRAFT")
]
let recommendedProfileProperties = [
// The following two properties are from LabProcess
    ProfileRow.create("executesLabProtocol",  Recommended, ONE,       [   (BioSchemas.LabProtocol, END)], 
                                                                          "The protocol executed. In this case, it refers to the multitype entity of the ARC CWL Workflow Profile with File, SoftwareSourceCode, ComputationalWorkflow and LabProtocol", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("parameterValue",       Recommended, ONE,       [   (Schema.PropertyValue, END)], 
                                                                          "A parameter value of the workflow process, usually a key-value pair using ontology terms", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
// Required -> Recommended
    ProfileRow.create("name",                 Required, ONE,          [   (Schema.Text, END)], 
                                                                          "Short human-readable description of the execution.", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
]
let optionalProfileProperties = [
// Recommended -> Optional
    ProfileRow.create("endTime",              Optional, ONE,          [   (Schema.DateTime, OR)
                                                                          (Schema.Time, END)], 
                                                                          "The time the process ended, i.e. when the last of the entities in result has been created. SHOULD be a DateTime in ISO 8601 format.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
// Recommended -> Optional
    ProfileRow.create("description",          Optional, ONE,          [   (Schema.Text, OR)
                                                                          (Schema.TextObject, END)], 
                                                                          "Details of the execution, for instance command line arguments or settings. This field is for information only, no particular structure is to be assumed.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("actionProcess",        Optional, ONE,          [   (Schema.HowTo, END)], 
                                                                          "Description of the process by which the action was performed.", 
                                                                          "https://schema.org/Action")
    ProfileRow.create("actionStatus",         Optional, ONE,          [   (Schema.ActionStatusType, END)], 
                                                                          "SHOULD be CompletedActionStatus if the process completed successfully or FailedActionStatus if it failed to complete. In the latter case, consumers should be prepared for the absence of any dependent actions in the metadata. If this attribute is not specified, consumers should assume that the process completed successfully.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("error",                Optional, MANY,         [   (Schema.Thing, END)], 
                                                                          "Additional information on the cause of the failure, such as an error message from the application, if available. SHOULD NOT be specified unless actionStatus is set to FailedActionStatus.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("location",             Optional, ONE,          [   (Schema.Place, OR)
                                                                          (Schema.PostalAddress, OR)
                                                                          (Schema.Text, OR)
                                                                          (Schema.VirtualLocation, END)], 
                                                                          "The location of, for example, where an event is happening, where an organization is located, or where an action takes place.", 
                                                                          "https://schema.org/Action")
    ProfileRow.create("participant",          Optional, MANY,         [   (Schema.Organization, OR)
                                                                          (Schema.Person, END)], 
                                                                          "Other co-agents that participated in the action indirectly. E.g. John wrote a book with Steve.", 
                                                                          "https://schema.org/Action")
    ProfileRow.create("provider",             Optional, MANY,         [   (Schema.Organization, OR)
                                                                          (Schema.Person, END)], 
                                                                          "The service provider, service operator, or service performer; the goods producer. Another party (a seller) may offer those services or goods on behalf of the provider. A provider may also serve as the seller. Supersedes carrier.", 
                                                                          "https://schema.org/Action")
    ProfileRow.create("startTime",            Optional, ONE,          [   (Schema.DateTime, OR)
                                                                          (Schema.Time, END)], 
                                                                          "The time the process started, i.e. the earliest time the process may have accessed an entity in object. SHOULD be a DateTime in ISO 8601 format.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
// endTime is a property of Action, but specifically mentioned as optional in the LabProcess schema
    ProfileRow.create("endTime",              Optional, ONE,          [   (Schema.DateTime, OR)
                                                                          (Schema.Time, END)], 
                                                                          "The endTime of something. For a reserved event or service (e.g. FoodEstablishmentReservation), the time that it is expected to end. For actions that span a period of time, when the action was performed. E.g. John wrote a book from January to December. For media, including audio and video, it's the time offset of the end of a clip within a larger file.", 
                                                                          "https://bioschemas.org/types/LabProcess/0.1-DRAFT")
    ProfileRow.create("target",               Optional, ONE,          [   (Schema.EntryPoint, OR)
                                                                          (Schema.URL, END)], 
                                                                          "Indicates a target EntryPoint, or url, for an Action.", 
                                                                          "https://schema.org/Action")
    ProfileRow.create("additionalType",       Optional, MANY,         [   (Schema.Text, OR)
                                                                          (Schema.URL, END)], 
                                                                          "An additional type for the item, typically used for adding more specific types from external vocabularies in microdata syntax. This is a relationship between something and a class that the thing is in. Typically the value is a URI-identified RDF class, and in this case corresponds to the use of rdf:type in RDF. Text values can be used sparingly, for cases where useful information can be added without their being an appropriate schema to reference. In the case of text values, the class label should follow the schema.org style guide.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("alternateName",        Optional, MANY,         [   (Schema.Text, END)], 
                                                                          "An alias for the item.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("disambiguatingDescription", Optional, ONE,     [   (Schema.Text, END)], 
                                                                          "A sub property of description. A short description of the item used to disambiguate from other, similar items. Information from other properties (in particular, name) may be necessary for the description to be useful for disambiguation.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("identifier",           Optional, MANY,         [   (Schema.PropertyValue, OR)
                                                                          (Schema.Text, OR)
                                                                          (Schema.URL, END)], 
                                                                          "The identifier property represents any kind of identifier for any kind of Thing, such as ISBNs, GTIN codes, UUIDs etc. Schema.org provides dedicated properties for representing many of these, either as textual strings or as URL (URI) links. See background notes for more details.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("image",                Optional, ONE,          [   (Schema.ImageObject, OR)
                                                                          (Schema.URL, END)], 
                                                                          "An image of the item. This can be a URL or a fully described ImageObject.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("mainEntityOfPage",     Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                          (Schema.URL, END)], 
                                                                          "Indicates a page (or other CreativeWork) for which this thing is the main entity being described. See background notes for details. Inverse property: mainEntity", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("potentialAction",      Optional, MANY,         [   (Schema.Action, END)], 
                                                                          "Indicates a potential Action, which describes an idealized action in which this thing would play an 'object' role.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("sameAs",               Optional, MANY,         [   (Schema.URL, END)], 
                                                                          "URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("subjectOf",            Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                          (Schema.Event, END)], 
                                                                          "A CreativeWork or Event about this Thing. Inverse property: about", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("url",                  Optional, ONE,          [   (Schema.URL, END)], 
                                                                          "URL of the item.", 
                                                                          "https://schema.org/Thing")
]

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"create-action-lab-process.generated.md"), 
    [
        "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
        "|----------|----------|-------------|---------------|-------------|----------------|"
    ]
    @ ["| <h4>Required Properties</h4> | | | | | |"]
    @ (requiredProfileProperties |> List.map ProfileRow.toTableRow)
    @ ["| <h4>Recommended Properties</h4> | | | | | |"]
    @ (recommendedProfileProperties |> List.map ProfileRow.toTableRow)
    @ ["| <h4>Optional Properties</h4> | | | | | |"]
    @ (optionalProfileProperties |> List.map ProfileRow.toTableRow)
)