type Required = 
    | Required 
    | Recommended 
    | Optional
    static member toString (r:Required) =
        match r with
        | Required -> "Required"
        | Recommended -> "Recommended"
        | Optional -> "Optional"

type Cardinality = 
    | ONE 
    | MANY 
    | SPECIFIC of int
    | ANY 
    static member toString (c:Cardinality) =
        match c with
        | ONE -> "ONE"
        | MANY -> "MANY"
        | SPECIFIC n -> string n
        | ANY -> "ANY"

type Conjunction =
    | AND
    | OR
    | END
    static member toString (c:Conjunction) =
        match c with
        | AND -> "<br>AND "
        | OR -> "<br>OR "
        | END -> ""

type SchemaType = {
    Name: string
    Domain: string
    Link: string
} with
    static member toLink (st: SchemaType) =
        match st.Domain with
        | "" -> sprintf "[%s](%s)" st.Name st.Link
        | _ -> sprintf "[%s/%s](%s)" st.Domain st.Name st.Link

type ProfileRow = {
    Property: string
    Required: Required
    Cardinality: Cardinality
    ExpectedType: (SchemaType * Conjunction) list
    Description: string
    SourceProfile: string
} with
    static member create(
        property: string,
        required: Required,
        cardinality: Cardinality,
        expectedType: (SchemaType * Conjunction) list,
        description: string,
        sourceProfile: string
    ) =
        { Property = property
          Required = required
          Cardinality = cardinality
          ExpectedType = expectedType
          Description = description
          SourceProfile = sourceProfile
        }
    static member toTableRow (row:ProfileRow) =
        let expectedTypes = row.ExpectedType |> List.map (fun (t, c) -> sprintf "%s%s" (SchemaType.toLink t) (Conjunction.toString c)) |> String.concat ""
        sprintf 
            "| **`%s`** | %s | %s | %s | %s | %s |" 
            row.Property 
            (Required.toString row.Required) 
            (Cardinality.toString row.Cardinality) 
            expectedTypes 
            row.Description 
            row.SourceProfile 

let IRI = { Name = "IRI"; Domain = ""; Link = "https://datatracker.ietf.org/doc/html/rfc3987#section-2" }

module Schema =
    let URL = { Name = "URL"; Domain = "schema.org"; Link = "https://schema.org/URL" }
    let Text = { Name = "Text"; Domain = "schema.org"; Link = "https://schema.org/Text" }
    let Number = { Name = "Number"; Domain = "schema.org"; Link = "https://schema.org/Number" }
    let Date = { Name = "Date"; Domain = "schema.org"; Link = "https://schema.org/Date" }
    let DateTime = { Name = "DateTime"; Domain = "schema.org"; Link = "https://schema.org/DateTime" }
    let Organization = { Name = "Organization"; Domain = "schema.org"; Link = "https://schema.org/Organization" }
    let Person = { Name = "Person"; Domain = "schema.org"; Link = "https://schema.org/Person" }
    let CreativeWork = { Name = "CreativeWork"; Domain = "schema.org"; Link = "https://schema.org/CreativeWork" }
    let SoftwareSourceCode = { Name = "SoftwareSourceCode"; Domain = "schema.org"; Link = "https://schema.org/SoftwareSourceCode" }
    let SoftwareApplication = { Name = "SoftwareApplication"; Domain = "schema.org"; Link = "https://schema.org/SoftwareApplication" }
    let ImageObject = { Name = "ImageObject"; Domain = "schema.org"; Link = "https://schema.org/ImageObject" }
    let DefinedTerm = { Name = "DefinedTerm"; Domain = "schema.org"; Link = "https://schema.org/DefinedTerm" }
    let PropertyValue = { Name = "PropertyValue"; Domain = "schema.org"; Link = "https://schema.org/PropertyValue" }
    let ComputerLanguage = { Name = "ComputerLanguage"; Domain = "schema.org"; Link = "https://schema.org/ComputerLanguage" }
    let Grant = { Name = "Grant"; Domain = "schema.org"; Link = "https://schema.org/Grant" }
    let Product = { Name = "Product"; Domain = "schema.org"; Link = "https://schema.org/Product" }
    let Comment = { Name = "Comment"; Domain = "schema.org"; Link = "https://schema.org/Comment" }
    let Thing = { Name = "Thing"; Domain = "schema.org"; Link = "https://schema.org/Thing" }
    let Boolean = { Name = "Boolean"; Domain = "schema.org"; Link = "https://schema.org/Boolean" }
    let Action = { Name = "Action"; Domain = "schema.org"; Link = "https://schema.org/Action" }
    let Event = { Name = "Event"; Domain = "schema.org"; Link = "https://schema.org/Event" }
    let Collection = { Name = "Collection"; Domain = "schema.org"; Link = "https://schema.org/Collection" }
    let Dataset = { Name = "Dataset"; Domain = "schema.org"; Link = "https://schema.org/Dataset" }
    let DataType = { Name = "DataType"; Domain = "schema.org"; Link = "https://schema.org/DataType" }
    let StructuredValue = { Name = "StructuredValue"; Domain = "schema.org"; Link = "https://schema.org/StructuredValue" }
    let MeasurementMethodEnum = { Name = "MeasurementMethodEnum"; Domain = "schema.org"; Link = "https://schema.org/MeasurementMethodEnum" }
    let MeasurementTypeEnumeration = { Name = "MeasurementTypeEnumeration"; Domain = "schema.org"; Link = "https://schema.org/MeasurementTypeEnumeration" }
    let Enumeration = { Name = "Enumeration"; Domain = "schema.org"; Link = "https://schema.org/Enumeration" }
    let QualitativeValue = { Name = "QualitativeValue"; Domain = "schema.org"; Link = "https://schema.org/QualitativeValue" }
    let QuantitativeValue = { Name = "QuantitativeValue"; Domain = "schema.org"; Link = "https://schema.org/QuantitativeValue" }
    let TextObject = { Name = "TextObject"; Domain = "schema.org"; Link = "https://schema.org/TextObject" }
    let HowTo = { Name = "HowTo"; Domain = "schema.org"; Link = "https://schema.org/HowTo" }
    let ActionStatusType = { Name = "ActionStatusType"; Domain = "schema.org"; Link = "https://schema.org/ActionStatusType" }
    let Time = { Name = "Time"; Domain = "schema.org"; Link = "https://schema.org/Time" }
    let Place = { Name = "Place"; Domain = "schema.org"; Link = "https://schema.org/Place" }
    let PostalAddress = { Name = "PostalAddress"; Domain = "schema.org"; Link = "https://schema.org/PostalAddress" }
    let VirtualLocation = { Name = "VirtualLocation"; Domain = "schema.org"; Link = "https://schema.org/VirtualLocation" }
    let EntryPoint = { Name = "EntryPoint"; Domain = "schema.org"; Link = "https://schema.org/EntryPoint" }
    let DataFeed = { Name = "DataFeed"; Domain = "schema.org"; Link = "https://schema.org/DataFeed" }

module BioSchemas =
    let ComputationalWorkflow = { Name = "ComputationalWorkflow"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/ComputationalWorkflow" }
    let LabProtocol = { Name = "LabProtocol"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/LabProtocol" }
    let FormalParameter = { Name = "FormalParameter"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/FormalParameter" }

module WorkflowRunProfile =
    let ProcessRun = { Name = "ProcessRun"; Domain = "workflow-run-crate"; Link = "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate" }
    let WorkflowRun = { Name = "WorkflowRun"; Domain = "workflow-run-crate"; Link = "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/" }
    let FormalParameter = { Name = "FormalParameter"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/FormalParameter" }

let requiredProfilePropertiesFormalParameter = [
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

let recommendedProfilePropertiesFormalParameter = [
    ProfileRow.create("name",               Recommended, ONE,       [   (Schema.Text, END)], 
                                                                    "SHOULD match the name of the corresponding workflow parameter slot, e.g. n_lines.", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate")
    ProfileRow.create("encodingFormat",     Recommended, MANY,      [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Media type typically expressed using a MIME format (see IANA site and MDN reference) e.g. application/zip for a SoftwareApplication binary, audio/mpeg for .mp3 etc.). In cases where a CreativeWork has several media type representations, encoding can be used to indicate each MediaObject alongside particular encodingFormat information. Unregistered or niche encoding and file formats can be indicated instead via the most appropriate URL, e.g. defining Web page or a Wikipedia/Wikidata entry. Supersedes fileFormat.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
    ProfileRow.create("sameAs",             Recommended, MANY,      [   (Schema.URL, END)], 
                                                                    "URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.", 
                                                                    "https://bioschemas.org/types/FormalParameter/1.0-RELEASE")
]

let optionalProfilePropertiesFormalParameter = [
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

let requiredProfilePropertiesPropertyValue = [
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("@type",              Required, MANY,         [   (Schema.Text, END)], 
                                                                    "Schema.org class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("name",               Required, ONE,          [   (Schema.Text, END)], 
                                                                    "The name of the item.", 
                                                                    "https://schema.org/Thing")
]

let recommendedProfilePropertiesPropertyValue = [
    ProfileRow.create("value",              Recommended, ONE,       [   (Schema.Boolean, OR)
                                                                        (Schema.Number, OR)
                                                                        (Schema.StructuredValue, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "The value of a QuantitativeValue (including Observation) or property value node.\n\nFor QuantitativeValue and MonetaryAmount, the recommended type for values is 'Number'.\nFor PropertyValue, it can be 'Text', 'Number', 'Boolean', or 'StructuredValue'.\nUse values from 0123456789 [Add to Citavi project by ISBN] (Unicode 'DIGIT ZERO' (U+0030) to 'DIGIT NINE' (U+0039)) rather than superficially similar Unicode symbols.\nUse '.' (Unicode 'FULL STOP' (U+002E)) rather than ',' to indicate a decimal point. Avoid using these symbols as a readability separator.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("exampleOfWork",      Recommended, ONE,       [   (IRI, END)], 
                                                                    "Identifier of the FormalParameter instance realized by this entity.", 
                                                                    "https://schema.org/PropertyValue")
]

let optionalProfilePropertiesPropertyValue = [
    ProfileRow.create("measurementMethod",  Optional, ONE,          [   (Schema.DefinedTerm, OR)
                                                                        (Schema.MeasurementMethodEnum, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A subproperty of measurementTechnique that can be used for specifying specific methods, in particular via MeasurementMethodEnum.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("measurementTechnique", Optional, MANY,       [   (Schema.DefinedTerm, OR)
                                                                        (Schema.MeasurementMethodEnum, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A technique, method or technology used in an Observation, StatisticalVariable or Dataset (or DataDownload, DataCatalog), corresponding to the method used for measuring the corresponding variable(s) (for datasets, described using variableMeasured; for Observation, a StatisticalVariable).\n\nOften but not necessarily each variableMeasured will have an explicit representation as (or mapping to) a property such as those defined in Schema.org, or other RDF vocabularies and 'knowledge graphs'. In that case the subproperty of variableMeasured called measuredProperty is applicable.\n\nThe measurementTechnique property helps when extra clarification is needed about how a measuredProperty was measured. This is oriented towards scientific and scholarly dataset publication but may have broader applicability; it is not intended as a full representation of measurement, but can often serve as a high level summary for dataset discovery.\n\nFor example, if variableMeasured is: molecule concentration, measurementTechnique could be: 'mass spectrometry' or 'nmr spectroscopy' or 'colorimetry' or 'immunofluorescence'. If the variableMeasured is 'depression rating', the measurementTechnique could be 'Zung Scale' or 'HAM-D' or 'Beck Depression Inventory'.\n\nIf there are several variableMeasured properties recorded for some given data object, use a PropertyValue for each variableMeasured and attach the corresponding measurementTechnique. The value can also be from an enumeration, organized as a MeasurementMethodEnumeration.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("propertyID",         Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A commonly used identifier for the characteristic represented by the property, e.g. a manufacturer or a standard code for a property. propertyID can be (1) a prefixed string, mainly meant to be used with standards for product properties; (2) a site-specific, non-prefixed string (e.g. the primary key of the property or the vendor-specific ID of the property), or (3) a URL indicating the type of the property, either pointing to an external vocabulary, or a Web resource that describes the property (e.g. a glossary entry). Standards bodies should promote a standard prefix for the identifiers of properties from their standards.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("unitCode",           Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The unit of measurement given using the UN/CEFACT Common Code (3 characters) or a URL. Other codes than the UN/CEFACT Common Code may be used with a prefix followed by a colon.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("unitText",           Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "A string or text indicating the unit of measurement. Useful if you cannot provide a standard unit code for unitCode.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("valueReference",     Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Enumeration, OR)
                                                                        (Schema.MeasurementTypeEnumeration, OR)
                                                                        (Schema.PropertyValue, OR)
                                                                        (Schema.QualitativeValue, OR)
                                                                        (Schema.QuantitativeValue, OR)
                                                                        (Schema.StructuredValue, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "A secondary value that provides additional information on the original value, e.g. a reference temperature or a type of measurement.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("maxValue",           Optional, ONE,          [   (Schema.Number, END)], 
                                                                    "The upper value of some characteristic or property.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("minValue",           Optional, ONE,          [   (Schema.Number, END)], 
                                                                    "The lower value of some characteristic or property.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("additionalType",     Optional, MANY,         [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "An additional type for the item, typically used for adding more specific types from external vocabularies in microdata syntax. This is a relationship between something and a class that the thing is in. Typically the value is a URI-identified RDF class, and in this case corresponds to the use of rdf:type in RDF. Text values can be used sparingly, for cases where useful information can be added without their being an appropriate schema to reference. In the case of text values, the class label should follow the schema.org style guide.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("alternateName",      Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "An alias for the item.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("description",        Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.TextObject, END)
                                                                    ], 
                                                                    "A description of the item.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("disambiguatingDescription", Optional, ONE,   [   (Schema.Text, END)], 
                                                                    "A sub property of description. A short description of the item used to disambiguate from other, similar items. Information from other properties (in particular, name) may be necessary for the description to be useful for disambiguation.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("identifier",         Optional, MANY,         [   (Schema.PropertyValue, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The identifier property represents any kind of identifier for any kind of Thing, such as ISBNs, GTIN codes, UUIDs etc. Schema.org provides dedicated properties for representing many of these, either as textual strings or as URL (URI) links. See background notes for more details.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("image",              Optional, ONE,          [   (Schema.ImageObject, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "An image of the item. This can be a URL or a fully described ImageObject.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("mainEntityOfPage",   Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Indicates a page (or other CreativeWork) for which this thing is the main entity being described. See background notes for details.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("sameAs",             Optional, MANY,         [   (Schema.URL, END)], 
                                                                    "URL of a reference Web page that unambiguously indicates the item's identity. E.g. the URL of the item's Wikipedia page, Wikidata entry, or official website.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("url",                Optional, ONE,          [   (Schema.URL, END)], 
                                                                    "URL of the item.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("potentialAction",    Optional, MANY,         [   (Schema.Action, END)], 
                                                                    "Indicates a potential Action, which describes an idealized action in which this thing would play an 'object' role.", 
                                                                    "https://schema.org/Thing")
    ProfileRow.create("subjectOf",          Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                        (Schema.Event, END)
                                                                    ], 
                                                                    "A CreativeWork or Event about this Thing.\nInverse property: about", 
                                                                    "https://schema.org/Thing")
]


let requiredProfilePropertiesCreateAction = [
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
let recommendedProfilePropertiesCreateAction = [
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
let optionalProfilePropertiesCreateAction = [
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

let optionalProfilePropertiesSoftwareApplication = [
    ProfileRow.create("applicationCategory",      Optional, ONE,         [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Type of software application, e.g. 'Game, Multimedia'.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("applicationSubCategory",   Optional, ONE,         [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Subcategory of the application, e.g. 'Arcade Game'.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("applicationSuite",         Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "The name of the application suite to which the application belongs (e.g. Excel belongs to Office).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("availableOnDevice",        Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "Device required to run the application. Used in cases where a specific make/model is required to run the application. Supersedes device.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("countriesNotSupported",    Optional, MANY,        [   (Schema.Text, END)], 
                                                                             "Countries for which the application is not supported. You can also provide the two-letter ISO 3166-1 alpha-2 country code.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("countriesSupported",       Optional, MANY,        [   (Schema.Text, END)], 
                                                                             "Countries for which the application is supported. You can also provide the two-letter ISO 3166-1 alpha-2 country code.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("downloadUrl",              Optional, ONE,         [   (Schema.URL, END)], 
                                                                             "If the file can be downloaded, URL to download the binary.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("featureList",              Optional, MANY,        [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Features or modules provided by this application (and possibly required by other applications).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("fileSize",                 Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "Size of the application / package (e.g. 18MB). In the absence of a unit (MB, KB etc.), KB will be assumed.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("installUrl",               Optional, ONE,         [   (Schema.URL, END)], 
                                                                             "URL at which the app may be installed, if different from the URL of the item.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("memoryRequirements",       Optional, ONE,         [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Minimum memory requirements.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("operatingSystem",          Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "Operating systems supported (Windows 7, OS X 10.6, Android 1.6).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("permissions",              Optional, MANY,        [   (Schema.Text, END)], 
                                                                             "Permission(s) required to run the app (for example, a mobile app may require full internet access or may run only on wifi).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("processorRequirements",    Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "Processor architecture required to run the application (e.g. IA64).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("releaseNotes",             Optional, MANY,        [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Description of what changed in this version.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("screenshot",               Optional, MANY,        [   (Schema.ImageObject, OR)
                                                                             (Schema.URL, END)], 
                                                                             "A link to a screenshot image of the app.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("softwareAddOn",            Optional, MANY,        [   (Schema.SoftwareApplication, END)], 
                                                                             "Additional content for a software application.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("softwareHelp",             Optional, MANY,        [   (Schema.CreativeWork, END)], 
                                                                             "Software application help.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("softwareRequirements",     Optional, MANY,        [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Component dependency requirements for application. This includes runtime environments and shared libraries that are not included in the application distribution package, but required to run the application (examples: DirectX, Java or .NET runtime). Supersedes requirements.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("softwareVersion",          Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "Version of the software instance.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("storageRequirements",      Optional, ONE,         [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Storage requirements (free space required).", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("supportingData",           Optional, MANY,        [   (Schema.DataFeed, END)], 
                                                                             "Supporting data for a SoftwareApplication.", 
                                                                             "https://schema.org/SoftwareApplication")
]



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
