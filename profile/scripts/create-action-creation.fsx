#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [
    ProfileRow.create("@id",                  Required, ONE,          [   (IRI, END)], 
                                                                          """A unique identifier for the execution, e.g. "urn:uuid:50ec5c76-1f7a-4130-8ef6-846756b228c1", "#f99a8e6c". MAY be an absolute URI, e.g. http://example.com/runs/846756b228c1. The use of randomly generated UUIDs (type 4) is RECOMMENDED. SHOULD be listed under mentions of the root data entity.""", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("@type",                Required, MANY,         [   (Schema.Text, END)], 
                                                                          "SHOULD be CreateAction to indicate that this tool created the result data entities. MAY be ActivateAction if the provenance does not include any result. MAY be UpdateAction if the tool modified an existing data entity or database in-place.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("instrument",           Required, MANY,         [   (Schema.Thing, END)], 
                                                                          "Identifier of the executed tool.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
]
let recommendedProfileProperties = [
    ProfileRow.create("agent",                Recommended, ONE,       [   (Schema.Organization, OR)
                                                                          (Schema.Person, END)], 
                                                                          "Identifier of a Person or Organization contextual entity that started/executed this tool.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("endTime",              Recommended, ONE,       [   (Schema.DateTime, OR)
                                                                          (Schema.Time, END)], 
                                                                          "The time the process ended, i.e. when the last of the entities in result has been created. SHOULD be a DateTime in ISO 8601 format.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("result",               Recommended, ONE,       [   (Schema.Thing, END)], 
                                                                          "The identifier of one or more entities that were created or modified by this action, e.g. output files.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("description",          Recommended, ONE,       [   (Schema.Text, OR)
                                                                          (Schema.TextObject, END)], 
                                                                          "Details of the execution, for instance command line arguments or settings. This field is for information only, no particular structure is to be assumed.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("name",                 Recommended, ONE,       [   (Schema.Text, END)], 
                                                                          "Short human-readable description of the execution.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
]
let optionalProfileProperties = [
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
    ProfileRow.create("object",               Optional, ONE,          [   (Schema.Thing, END)], 
                                                                          "The identifier of one or more entities of the RO-Crate that were consumed by this action, e.g. input files or reference datasets.", 
                                                                          "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
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
                                                                          "Indicates a page (or other CreativeWork) for which this thing is the main entity being described. See background notes for details.\nInverse property: mainEntity", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("potentialAction",      Optional, MANY,         [   (Schema.Action, END)], 
                                                                          "Indicates a potential Action, which describes an idealized action in which this thing would play an 'object' role.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("sameAs",               Optional, MANY,         [   (Schema.URL, END)], 
                                                                          "URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("subjectOf",            Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                          (Schema.Event, END)], 
                                                                          "A CreativeWork or Event about this Thing.\nInverse property: about", 
                                                                          "https://schema.org/Thing")
    ProfileRow.create("url",                  Optional, ONE,          [   (Schema.URL, END)], 
                                                                          "URL of the item.", 
                                                                          "https://schema.org/Thing")
]

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"create-action.generated.md"), 
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