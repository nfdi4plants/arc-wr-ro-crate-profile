#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://bioschemas.org/profiles/FormalParameter/1.1-DRAFT")
    ProfileRow.create("@type",              Required, MANY,         [   (Schema.Text, END)], 
                                                                    "Schema.org/Bioschemas class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "https://bioschemas.org/profiles/FormalParameter/1.1-DRAFT")
    ProfileRow.create("additionalType",     Required, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.Dataset, OR)
                                                                        (Schema.Collection, OR)
                                                                        (Schema.PropertyValue, OR)
                                                                        (Schema.DataType, END)
                                                                    ], 
                                                                    "SHOULD include: File, Dataset or Collection if it maps to a file, directory or multi-file dataset, respectively; PropertyValue if it maps to a dictionary-like structured value (e.g. a CWL record); DataType or one of its subtypes (e.g. Integer) if it maps to a non-structured value.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate")
]

let recommendedProfileProperties = [
// Required according to https://www.researchobject.org/ro-crate/specification/1.1/workflows.html when describing inputs or outputs
// Required -> Recommended
    ProfileRow.create("encodingFormat",     Required, MANY,         [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Media type typically expressed using a MIME format (see IANA site and MDN reference) e.g. application/zip for a SoftwareApplication binary, audio/mpeg for .mp3 etc.). In cases where a CreativeWork has several media type representations, encoding can be used to indicate each MediaObject alongside particular encodingFormat information. Unregistered or niche encoding and file formats can be indicated instead via the most appropriate URL, e.g. defining Web page or a Wikipedia/Wikidata entry. Supersedes fileFormat.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE,https://www.researchobject.org/ro-crate/specification/1.1/workflows.html")
]

let optionalProfileProperties = [
// Required according to https://www.researchobject.org/ro-crate/specification/1.1/workflows.html, but only recommended
// in https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate
// Recommended -> Optional
    ProfileRow.create("name",               Recommended, ONE,       [   (Schema.Text, END)], 
                                                                    "SHOULD match the name of the corresponding workflow parameter slot, e.g. n_lines.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate")
// Recommended -> Optional
    ProfileRow.create("sameAs",             Recommended, MANY,      [   (Schema.URL, END)], 
                                                                    "URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("description",        Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "A description of the parameter's purpose, e.g. Number of lines.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate")
    ProfileRow.create("workExample",        Optional, ONE,          [   (IRI, END)], 
                                                                    "Identifier of the data entity or PropertyValue instance that realizes this parameter. The data entity or PropertyValue instance SHOULD refer to this parameter via exampleOfWork.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/")
    ProfileRow.create("defaultValue",       Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.Thing, END)
                                                                    ], 
                                                                    "The default value of the input. For literals, this is a literal value. For objects, it is an ID reference.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("valueRequired",      Optional, ONE,          [   (Schema.Boolean, END)], 
                                                                    "For an input, whether a value must be specified for the workflow to be run. Default is false.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("identifier",         Optional, MANY,         [   (Schema.PropertyValue, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The identifier property represents any kind of identifier for any kind of Thing, such as ISBNs, GTIN codes, UUIDs etc. Schema.org provides dedicated properties for representing many of these, either as textual strings or as URL (URI) links.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("image",              Optional, ONE,          [   (Schema.ImageObject, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "An image of the item. This can be a URL or a fully described ImageObject.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("mainEntityOfPage",   Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Indicates a page (or other CreativeWork) for which this thing is the main entity being described. See background notes for details. Inverse property: mainEntity.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("potentialAction",    Optional, MANY,         [   (Schema.Action, END)], 
                                                                    "Indicates a potential Action, which describes an idealized action in which this thing would play an 'object' role.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("subjectOf",          Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                        (Schema.Event, END)
                                                                    ], 
                                                                    "A CreativeWork or Event about this Thing. Inverse property: about.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("url",                Optional, ONE,          [   (Schema.URL, END)], 
                                                                    "URL of the item.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("alternateName",      Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "An alias for the item.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("disambiguatingDescription", Optional, ONE,   [  (Schema.Text, END)], 
                                                                    "A sub property of description. A short description of the item used to disambiguate from other, similar items. Information from other properties (in particular, name) may be necessary for the description to be useful for disambiguation.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
]

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"formal-parameter.generated.md"), 
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