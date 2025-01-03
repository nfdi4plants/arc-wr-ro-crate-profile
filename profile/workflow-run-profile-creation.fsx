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
    let AggregateRating = { Name = "AggregateRating"; Domain = "schema.org"; Link = "https://schema.org/AggregateRating" }
    let WebPage = { Name = "WebPage"; Domain = "schema.org"; Link = "https://schema.org/WebPage" }
    let MediaObject = { Name = "MediaObject"; Domain = "schema.org"; Link = "https://schema.org/MediaObject" }
    let ItemList = { Name = "ItemList"; Domain = "schema.org"; Link = "https://schema.org/ItemList" }
    let Audience = { Name = "Audience"; Domain = "schema.org"; Link = "https://schema.org/Audience" }
    let AudioObject = { Name = "AudioObject"; Domain = "schema.org"; Link = "https://schema.org/AudioObject" }
    let Clip = { Name = "Clip"; Domain = "schema.org"; Link = "https://schema.org/Clip" }
    let MusicRecording = { Name = "MusicRecording"; Domain = "schema.org"; Link = "https://schema.org/MusicRecording" }
    let Integer = { Name = "Integer"; Domain = "schema.org"; Link = "https://schema.org/Integer" }
    let Rating = { Name = "Rating"; Domain = "schema.org"; Link = "https://schema.org/Rating" }
    let CorrectionComment = { Name = "CorrectionComment"; Domain = "schema.org"; Link = "https://schema.org/CorrectionComment" }
    let Country = { Name = "Country"; Domain = "schema.org"; Link = "https://schema.org/Country" }
    let IPTCDigitalSourceEnumeration = { Name = "IPTCDigitalSourceEnumeration"; Domain = "schema.org"; Link = "https://schema.org/IPTCDigitalSourceEnumeration" }
    let AlignmentObject = { Name = "AlignmentObject"; Domain = "schema.org"; Link = "https://schema.org/AlignmentObject" }
    let Language = { Name = "Language"; Domain = "schema.org"; Link = "https://schema.org/Language" }
    let InteractionCounter = { Name = "InteractionCounter"; Domain = "schema.org"; Link = "https://schema.org/InteractionCounter" }
    let Claim = { Name = "Claim"; Domain = "schema.org"; Link = "https://schema.org/Claim" }
    let Demand = { Name = "Demand"; Domain = "schema.org"; Link = "https://schema.org/Demand" }
    let Offer = { Name = "Offer"; Domain = "schema.org"; Link = "https://schema.org/Offer" }
    let PublicationEvent = { Name = "PublicationEvent"; Domain = "schema.org"; Link = "https://schema.org/PublicationEvent" }
    let Review = { Name = "Review"; Domain = "schema.org"; Link = "https://schema.org/Review" }
    let SizeSpecification = { Name = "SizeSpecification"; Domain = "schema.org"; Link = "https://schema.org/SizeSpecification" }
    let Duration = { Name = "Duration"; Domain = "schema.org"; Link = "https://schema.org/Duration" }
    let VideoObject = { Name = "VideoObject"; Domain = "schema.org"; Link = "https://schema.org/VideoObject" }

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

let optionalProfilePropertiesCreativeWork = [
    // Properties from CreativeWork
    ProfileRow.create("about",              Optional, ONE,          [   (Schema.Thing, END)], 
                                                                    "The subject matter of the content. Inverse property: subjectOf.", 
                                                                    "https://schema.org/about")

    ProfileRow.create("abstract",           Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "An abstract is a short description that summarizes a CreativeWork.", 
                                                                    "https://schema.org/abstract")

    ProfileRow.create("accessMode",         Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "The human sensory perceptual system or cognitive faculty through which a person may process or perceive information. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessMode")

    ProfileRow.create("accessModeSufficient", Optional, MANY,       [   (Schema.ItemList, END)], 
                                                                    "A list of single or combined accessModes that are sufficient to understand all the intellectual content of a resource. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessModeSufficient")

    ProfileRow.create("accessibilityAPI",   Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "Indicates that the resource is compatible with the referenced accessibility API. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessibilityAPI")

    ProfileRow.create("accessibilityControl", Optional, MANY,       [   (Schema.Text, END)], 
                                                                    "Identifies input methods that are sufficient to fully control the described resource. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessibilityControl")

    ProfileRow.create("accessibilityFeature", Optional, MANY,       [   (Schema.Text, END)], 
                                                                    "Content features of the resource, such as accessible media, alternatives, and supported enhancements for accessibility. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessibilityFeature")

    ProfileRow.create("accessibilityHazard", Optional, MANY,        [   (Schema.Text, END)], 
                                                                    "A characteristic of the described resource that is physiologically dangerous to some users. Related to WCAG 2.0 guideline 2.3. Values should be drawn from the approved vocabulary.", 
                                                                    "https://schema.org/accessibilityHazard")

    ProfileRow.create("accessibilitySummary", Optional, ONE,        [   (Schema.Text, END)], 
                                                                    "A human-readable summary of specific accessibility features or deficiencies, consistent with the other accessibility metadata but expressing subtleties such as 'short descriptions are present but long descriptions will be needed for non-visual users' or 'short descriptions are present and no long descriptions are needed'.", 
                                                                    "https://schema.org/accessibilitySummary")

    ProfileRow.create("accountablePerson",  Optional, ONE,          [   (Schema.Person, END)], 
                                                                    "Specifies the Person that is legally accountable for the CreativeWork.", 
                                                                    "https://schema.org/accountablePerson")

    ProfileRow.create("acquireLicensePage", Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "Indicates a page documenting how licenses can be purchased or otherwise acquired, for the current item.", 
                                                                    "https://schema.org/acquireLicensePage")

    ProfileRow.create("aggregateRating",    Optional, ONE,          [   (Schema.AggregateRating, END)], 
                                                                    "The overall rating, based on a collection of reviews or ratings, of the item.", 
                                                                    "https://schema.org/aggregateRating")

    ProfileRow.create("alternativeHeadline", Optional, ONE,         [   (Schema.Text, END)], 
                                                                    "A secondary title of the CreativeWork.", 
                                                                    "https://schema.org/alternativeHeadline")

    ProfileRow.create("archivedAt",         Optional, ONE,          [   (Schema.URL, OR)
                                                                        (Schema.WebPage, END)], 
                                                                    "Indicates a page or other link involved in archival of a CreativeWork. In the case of MediaReview, the items in a MediaReviewItem may often become inaccessible, but be archived by archival, journalistic, activist, or law enforcement organizations. In such cases, the referenced page may not directly publish the content.", 
                                                                    "https://schema.org/archivedAt")

    ProfileRow.create("assesses",           Optional, ONE,          [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The item being described is intended to assess the competency or learning outcome defined by the referenced term.", 
                                                                    "https://schema.org/assesses")

    ProfileRow.create("associatedMedia",    Optional, ONE,          [   (Schema.MediaObject, END)], 
                                                                    "A media object that encodes this CreativeWork. This property is a synonym for encoding.", 
                                                                    "https://schema.org/associatedMedia")

    ProfileRow.create("audience",           Optional, MANY,         [   (Schema.Audience, END)], 
                                                                    "An intended audience, i.e., a group for whom something was created. Supersedes serviceAudience.", 
                                                                    "https://schema.org/audience")

    ProfileRow.create("audio",              Optional, ONE,          [   (Schema.AudioObject, OR)
                                                                        (Schema.Clip, OR)
                                                                        (Schema.MusicRecording, END)], 
                                                                    "An embedded audio object.", 
                                                                    "https://schema.org/audio")

    ProfileRow.create("author",             Optional, MANY,         [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "The author of this content or rating. Please note that author is special in that HTML 5 provides a special mechanism for indicating authorship via the rel tag. That is equivalent to this and may be used interchangeably.", 
                                                                    "https://schema.org/author")

    ProfileRow.create("award",              Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "An award won by or for this item. Supersedes awards.", 
                                                                    "https://schema.org/award")

    ProfileRow.create("character",          Optional, MANY,         [   (Schema.Person, END)], 
                                                                    "Fictional person connected with a creative work.", 
                                                                    "https://schema.org/character")

    ProfileRow.create("citation",           Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                        (Schema.Text, END)], 
                                                                    "A citation or reference to another creative work, such as another publication, web page, scholarly article, etc.", 
                                                                    "https://schema.org/citation")

    ProfileRow.create("comment",            Optional, MANY,         [   (Schema.Comment, END)], 
                                                                    "Comments, typically from users.", 
                                                                    "https://schema.org/comment")

    ProfileRow.create("commentCount",       Optional, ONE,          [   (Schema.Integer, END)], 
                                                                    "The number of comments this CreativeWork (e.g., Article, Question or Answer) has received. This is most applicable to works published in Web sites with commenting system; additional comments may exist elsewhere.", 
                                                                    "https://schema.org/commentCount")

    ProfileRow.create("conditionsOfAccess", Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "Conditions that affect the availability of, or access to, the CreativeWork. These may include location-based restrictions, time-based restrictions, or requirements for subscription or registration.", 
                                                                    "https://schema.org/conditionsOfAccess")

    ProfileRow.create("contentLocation",    Optional, ONE,          [   (Schema.Place, END)], 
                                                                    "The location depicted or described in the content. For example, the location in a photograph or painting.", 
                                                                    "https://schema.org/contentLocation")

    ProfileRow.create("contentRating",      Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.Rating, END)], 
                                                                    "Official rating of a CreativeWork, e.g., 'MPAA PG-13'.", 
                                                                    "https://schema.org/contentRating")

    ProfileRow.create("contentReferenceTime", Optional, ONE,        [   (Schema.DateTime, END)], 
                                                                    "The specific time described by a creative work, for works (e.g. articles, video objects etc.) that emphasise a particular moment within an Event.", 
                                                                    "https://schema.org/contentReferenceTime")

    ProfileRow.create("contributor",        Optional, MANY,         [   (Schema.Person, OR)
                                                                        (Schema.Organization, END)], 
                                                                    "A secondary contributor to the CreativeWork or Event.", 
                                                                    "https://schema.org/contributor")

    ProfileRow.create("copyrightHolder",    Optional, ONE,          [   (Schema.Person, OR)
                                                                        (Schema.Organization, END)], 
                                                                    "The party holding the legal copyright to the CreativeWork.", 
                                                                    "https://schema.org/copyrightHolder")

    ProfileRow.create("copyrightYear",      Optional, ONE,          [   (Schema.Number, END)], 
                                                                    "The year of the copyright of the CreativeWork, for example, 2018.", 
                                                                    "https://schema.org/copyrightYear")

    ProfileRow.create("correction",         Optional, MANY,         [   (Schema.CorrectionComment, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A correction to this CreativeWork, either via a CorrectionComment, textually or in another document.", 
                                                                    "https://schema.org/correction")

    ProfileRow.create("creativeWorkStatus", Optional, ONE,          [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The status of a creative work in terms of its stage in a lifecycle. Example terms include 'draft', 'published', or 'archived'.", 
                                                                    "https://schema.org/creativeWorkStatus")

    ProfileRow.create("countryOfOrigin",    Optional, ONE,          [   (Schema.Country, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The country of origin of something, including products as well as creative works such as movie and TV content. In the case of TV and movie, this would be the country of the principle offices of the production company or individual responsible for the movie. For other kinds of CreativeWork it is difficult to provide fully general guidance, and properties such as contentLocation and locationCreated may be more applicable. In the case of products, the country of origin of the product. The exact interpretation of this may vary by context and product type, and cannot be fully enumerated here. ", 
                                                                    "https://schema.org/creativeWorkStatus")

    ProfileRow.create("creator",            Optional, MANY,         [   (Schema.Person, OR)
                                                                        (Schema.Organization, END)], 
                                                                    "The creator/author of this CreativeWork. This is the same as the Author property for CreativeWork.", 
                                                                    "https://schema.org/creator")

    ProfileRow.create("creditText",         Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "Text that can be used to credit person(s) and/or organization(s) associated with a published Creative Work.", 
                                                                    "https://schema.org/creator")

    ProfileRow.create("dateCreated",        Optional, ONE,          [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)], 
                                                                    "The date on which the CreativeWork was created or the item was added to a DataFeed.", 
                                                                    "https://schema.org/dateCreated")

    ProfileRow.create("dateModified",       Optional, ONE,          [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)], 
                                                                    "The date on which the CreativeWork was most recently modified or when the item's entry was modified within a DataFeed.", 
                                                                    "https://schema.org/dateModified")

    ProfileRow.create("datePublished",      Optional, ONE,          [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)], 
                                                                    "Date of first publication or broadcast. For example the date a CreativeWork was broadcast or a Certification was issued.", 
                                                                    "https://schema.org/datePublished")

    ProfileRow.create("digitalSourceType",  Optional, ONE,          [   (Schema.IPTCDigitalSourceEnumeration, END)], 
                                                                    "Indicates an IPTCDigitalSourceEnumeration code indicating the nature of the digital source(s) for some CreativeWork.", 
                                                                    "https://schema.org/datePublished")

    ProfileRow.create("discussionUrl",      Optional, ONE,          [   (Schema.URL, END)], 
                                                                    "A link to the page containing the comments of the CreativeWork.", 
                                                                    "https://schema.org/discussionUrl")

    ProfileRow.create("editEIDR",           Optional, MANY,         [   (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    """An EIDR (Entertainment Identifier Registry) identifier representing a specific edit / edition for a work of film or television. For example, the motion picture known as "Ghostbusters" whose titleEIDR is "10.5240/7EC7-228A-510A-053E-CBB8-J" has several edits, e.g. "10.5240/1F2A-E1C5-680A-14C6-E76B-I" and "10.5240/8A35-3BEE-6497-5D12-9E4F-3". Since schema.org types like Movie and TVEpisode can be used for both works and their multiple expressions, it is possible to use titleEIDR alone (for a general description), or alongside editEIDR for a more edit-specific description.""", 
                                                                    "https://schema.org/editor")

    ProfileRow.create("editor",             Optional, MANY,         [   (Schema.Person, END)], 
                                                                    "Specifies the Person who edited the CreativeWork.", 
                                                                    "https://schema.org/editor")

    ProfileRow.create("educationalAlignment", Optional, ONE,        [   (Schema.AlignmentObject, END)], 
                                                                    "An alignment to an established educational framework.This property should not be used where the nature of the alignment can be described using a simple property, for example to express that a resource teaches or assesses a competency.", 
                                                                    "https://schema.org/educationalAlignment")

    ProfileRow.create("educationalLevel",   Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "The level in terms of progression through an educational or training context. Examples of educational levels include 'beginner', 'intermediate' or 'advanced', and formal sets of level indicators.", 
                                                                    "https://schema.org/educationalUse")

    ProfileRow.create("educationalUse",     Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The purpose of a work in the context of education; for example, 'assignment', 'group work'.", 
                                                                    "https://schema.org/educationalUse")

    ProfileRow.create("encoding",           Optional, MANY,         [   (Schema.MediaObject, END)], 
                                                                    "A media object that encodes this CreativeWork. This property is a synonym for associatedMedia. Supersedes encodings. Inverse property: encodesCreativeWork", 
                                                                    "https://schema.org/encoding")

    ProfileRow.create("encodingFormat",     Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    " Media type typically expressed using a MIME format (see IANA site and MDN reference), e.g. application/zip for a SoftwareApplication binary, audio/mpeg for .mp3 etc. In cases where a CreativeWork has several media type representations, encoding can be used to indicate each MediaObject alongside particular encodingFormat information. Unregistered or niche encoding and file formats can be indicated instead via the most appropriate URL, e.g. defining Web page or a Wikipedia/Wikidata entry. Supersedes fileFormat. ", 
                                                                    "https://schema.org/encodingFormat")

    ProfileRow.create("exampleOfWork",      Optional, ONE,          [   (Schema.CreativeWork, END)], 
                                                                    "A creative work that this work is an example/instance/realization/derivation of. Inverse property: workExample", 
                                                                    "https://schema.org/exampleOfWork")

    ProfileRow.create("expires",            Optional, ONE,          [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)], 
                                                                    "Date the content expires and is no longer useful or available. For example a VideoObject or NewsArticle whose availability or relevance is time-limited, a ClaimReview fact check whose publisher wants to indicate that it may no longer be relevant (or helpful to highlight) after some date, or a Certification the validity has expired.", 
                                                                    "https://schema.org/expires")

    ProfileRow.create("funder",             Optional, MANY,         [   (Schema.Person, OR)
                                                                        (Schema.Organization, END)], 
                                                                    "A person or organization that supports (sponsors) something through some kind of financial contribution.", 
                                                                    "https://schema.org/funder")

    ProfileRow.create("funding",            Optional, MANY,         [   (Schema.Grant, END)], 
                                                                    "A Grant that directly or indirectly provide funding or sponsorship for this item. See also ownershipFundingInfo. Inverse property: fundedItem", 
                                                                    "https://schema.org/funder")

    ProfileRow.create("genre",              Optional, MANY,         [   (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "Genre of the creative work, broadcast channel, or group.", 
                                                                    "https://schema.org/genre")

    ProfileRow.create("hasPart",            Optional, MANY,         [   (Schema.CreativeWork, END)], 
                                                                    "Indicates an item or CreativeWork that is part of this item, or CreativeWork (in some sense). Inverse property: isPartOf", 
                                                                    "https://schema.org/hasPart")

    ProfileRow.create("headline",           Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "Headline of the article.", 
                                                                    "https://schema.org/headline")

    ProfileRow.create("inLanguage",         Optional, ONE,          [   (Schema.Language, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The language of the content or performance or used in an action. Please use one of the language codes from the IETF BCP 47 standard. See also availableLanguage. Supersedes language.", 
                                                                    "https://schema.org/inLanguage")

    ProfileRow.create("interactionStatistic", Optional, MANY,       [   (Schema.InteractionCounter, END)], 
                                                                    "The number of interactions for the CreativeWork using the WebSite or SoftwareApplication. The most specific child type of InteractionCounter should be used. Supersedes interactionCount.", 
                                                                    "https://schema.org/interactionStatistic")

    ProfileRow.create("interactivityType",  Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "The predominant mode of learning supported by the learning resource. Acceptable values are 'active', 'expositive', or 'mixed'.", 
                                                                    "https://schema.org/interactivityType")

                                                                    
    ProfileRow.create("interpretedAsClaim", Optional, ONE,          [   (Schema.Claim, END)], 
                                                                    "Used to indicate a specific claim contained, implied, translated or refined from the content of a MediaObject or other CreativeWork. The interpreting party can be indicated using claimInterpreter.", 
                                                                    "https://schema.org/interactivityType")

    ProfileRow.create("isAccessibleForFree", Optional, ONE,         [   (Schema.Boolean, END)], 
                                                                    "A flag to signal that the item, event, or place is accessible for free.", 
                                                                    "https://schema.org/isAccessibleForFree")

    ProfileRow.create("isBasedOn",          Optional, MANY,         [   (Schema.CreativeWork, OR)
                                                                        (Schema.Product, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A resource that was used in the creation of this resource. This term can be repeated for multiple sources. Supersedes isBasedOnUrl.", 
                                                                    "https://schema.org/isBasedOn")

    ProfileRow.create("isFamilyFriendly",   Optional, ONE,          [   (Schema.Boolean, END)], 
                                                                    "Indicates whether this content is family-friendly.", 
                                                                    "https://schema.org/isFamilyFriendly")

    ProfileRow.create("isPartOf",           Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "Indicates a CreativeWork that this CreativeWork is (in some sense) part of. Inverse property: hasPart", 
                                                                    "https://schema.org/isPartOf")

    ProfileRow.create("keywords",           Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "Keywords or tags used to describe some item. Multiple textual entries in a keywords list are typically delimited by commas, or by repeating the property.", 
                                                                    "https://schema.org/keywords")

    ProfileRow.create("learningResourceType", Optional, ONE,        [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The predominant type or kind characterizing the learning resource. For example, 'presentation', 'handout'.", 
                                                                    "https://schema.org/learningResourceType")

    ProfileRow.create("license",            Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A license document that applies to this content, typically indicated by URL.", 
                                                                    "https://schema.org/license")

    ProfileRow.create("locationCreated",    Optional, ONE,          [   (Schema.Place, END)], 
                                                                    "The location where the CreativeWork was created, which may not be the same as the location depicted in the CreativeWork.", 
                                                                    "https://schema.org/locationCreated")

    ProfileRow.create("mainEntity",         Optional, ONE,          [   (Schema.Thing, END)], 
                                                                    "Indicates the primary entity described in some page or other CreativeWork. Inverse property: mainEntityOfPage.", 
                                                                    "https://schema.org/mainEntity")

    ProfileRow.create("maintainer",         Optional, ONE,          [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    """A maintainer of a Dataset, software package (SoftwareApplication), or other Project. A maintainer is a Person or Organization that manages contributions to, and/or publication of, some (typically complex) artifact. It is common for distributions of software and data to be based on "upstream" sources. When maintainer is applied to a specific version of something e.g. a particular version or packaging of a Dataset, it is always possible that the upstream source has a different maintainer. The isBasedOn property can be used to indicate such relationships between datasets to make the different maintenance roles clear. Similarly in the case of software, a package may have dedicated maintainers working on integration into software distributions such as Ubuntu, as well as upstream maintainers of the underlying work.""", 
                                                                    "https://schema.org/mainEntityOfPage")

    ProfileRow.create("material",           Optional, MANY,         [   (Schema.Product, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A material that something is made from, e.g., leather, wool, cotton, paper.", 
                                                                    "https://schema.org/material")

    ProfileRow.create("materialExtent",     Optional, ONE,          [   (Schema.QuantitativeValue, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The quantity of the materials being described or an expression of the physical space they occupy.", 
                                                                    "https://schema.org/materialExtent")

    ProfileRow.create("mentions",           Optional, MANY,         [   (Schema.Thing, END)], 
                                                                    "Indicates that the CreativeWork contains a reference to, but is not necessarily about, a concept.", 
                                                                    "https://schema.org/mentions")

    ProfileRow.create("offers",             Optional, MANY,         [   (Schema.Demand, OR)
                                                                        (Schema.Offer, END)], 
                                                                    "An offer to provide this item—for example, an offer to sell a product, rent the DVD of a movie, perform a service, or give away tickets to an event. Use businessFunction to indicate the kind of transaction offered, i.e. sell, lease, etc. This property can also be used to describe a Demand. While this property is listed as expected on a number of common types, it can be used in others. In that case, using a second type, such as Product or a subtype of Product, can clarify the nature of the offer. Inverse property: itemOffered", 
                                                                    "https://schema.org/offers")

    ProfileRow.create("pattern",            Optional, ONE,          [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "A pattern that something has, for example 'polka dot', 'striped', 'Canadian flag'. Values are typically expressed as text, although links to controlled value schemes are also supported.", 
                                                                    "https://schema.org/position")

    ProfileRow.create("position",           Optional, ONE,          [   (Schema.Integer, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The position of an item in a series or sequence of items.", 
                                                                    "https://schema.org/position")

    ProfileRow.create("producer",           Optional, MANY,         [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "The person or organization who produced the work (e.g. music album, movie, TV/radio series etc.).", 
                                                                    "https://schema.org/producer")
    ProfileRow.create("provider",           Optional, MANY,         [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "The service provider, service operator, or service performer; the goods producer. Another party (a seller) may offer those services or goods on behalf of the provider. A provider may also serve as the seller. Supersedes carrier.", 
                                                                    "https://schema.org/provider")

    ProfileRow.create("publication",        Optional, ONE,          [   (Schema.PublicationEvent, END)], 
                                                                    "A publication event associated with the item.", 
                                                                    "https://schema.org/publication")

    ProfileRow.create("publisher",          Optional, ONE,          [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "The publisher of the CreativeWork.", 
                                                                    "https://schema.org/publisher")

    ProfileRow.create("publisherImprint",   Optional, ONE,          [   (Schema.Organization, END)], 
                                                                    "The publishing division which published the CreativeWork.", 
                                                                    "https://schema.org/publisherImprint")

    ProfileRow.create("publishingPrinciples", Optional, ONE,        [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "The publishingPrinciples property indicates (typically via URL) a document describing the editorial principles of an Organization (or individual, e.g. a Person writing a blog) that relate to their activities as a publisher, e.g. ethics or diversity policies. When applied to a CreativeWork (e.g. NewsArticle) the principles are those of the party primarily responsible for the creation of the CreativeWork. While such policies are most typically expressed in natural language, sometimes related information (e.g. indicating a funder) can be expressed using schema.org terminology. ", 
                                                                    "https://schema.org/publishingPrinciples")

    ProfileRow.create("recordedAt",         Optional, ONE,          [   (Schema.Event, END)], 
                                                                    "The Event where the CreativeWork was recorded. The CreativeWork may capture all or part of the event. Inverse property: recordedIn", 
                                                                    "https://schema.org/recordedAt")

    ProfileRow.create("releasedEvent",      Optional, ONE,          [   (Schema.PublicationEvent, END)], 
                                                                    "The place and time the release was issued, expressed as a PublicationEvent.", 
                                                                    "https://schema.org/releasedEvent")

    ProfileRow.create("review",             Optional, MANY,         [   (Schema.Review, END)], 
                                                                    "A review of the item.", 
                                                                    "https://schema.org/review")

    ProfileRow.create("schemaVersion",      Optional, ONE,          [   (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "Indicates (by URL or string) a particular version of a schema used in some CreativeWork. For example, a document could declare a schemaVersion using an URL such as 'http://schema.org/version/2.0/'.", 
                                                                    "https://schema.org/schemaVersion")

    ProfileRow.create("sdDatePublished",    Optional, ONE,          [   (Schema.Date, END)], 
                                                                    "Indicates the date on which the current structured data was generated / published. Typically used alongside sdPublisher.", 
                                                                    "https://schema.org/sdDatePublished")

    ProfileRow.create("sdLicense",          Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A license document that applies to this structured data, typically indicated by URL.", 
                                                                    "https://schema.org/sdLicense")

    ProfileRow.create("sdPublisher",        Optional, ONE,          [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "Indicates the party responsible for generating and publishing the current structured data markup, typically in cases where the structured data is derived automatically from existing published content but published on a different site. For example, student projects and open data initiatives often re-publish existing content with more explicitly structured metadata. The sdPublisher property helps make such practices more explicit.", 
                                                                    "https://schema.org/sdPublisher")

    ProfileRow.create("size",               Optional, ONE,          [   (Schema.DefinedTerm, OR)
                                                                        (Schema.QuantitativeValue, OR)
                                                                        (Schema.SizeSpecification, OR)
                                                                        (Schema.Text, END)], 
                                                                    "A standardized size of a product or creative work, specified either through a simple textual string (for example 'XL', '32Wx34L'), a QuantitativeValue with a unitCode, or a comprehensive and structured SizeSpecification; in other cases, the width, height, depth and weight properties may be more applicable.", 
                                                                    "https://schema.org/size")

    ProfileRow.create("sourceOrganization", Optional, ONE,          [   (Schema.Organization, END)], 
                                                                    "The Organization on whose behalf the creator was working.", 
                                                                    "https://schema.org/sourceOrganization")

    ProfileRow.create("spatial",            Optional, ONE,          [   (Schema.Place, END)], 
                                                                    """The "spatial" property can be used in cases when more specific properties (e.g. locationCreated, spatialCoverage, contentLocation) are not known to be appropriate.""", 
                                                                    "https://schema.org/spatial")

    ProfileRow.create("spatialCoverage",    Optional, ONE,          [   (Schema.Place, END)], 
                                                                    "The spatialCoverage of a CreativeWork indicates the place(s) which are the focus of the content. It is a subproperty of contentLocation intended primarily for more technical and detailed materials. For example with a Dataset, it indicates areas that the dataset describes: a dataset of New York weather would have spatialCoverage which was the place: the state of New York.", 
                                                                    "https://schema.org/spatialCoverage")

    ProfileRow.create("sponsor",            Optional, MANY,         [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)], 
                                                                    "A person or organization that supports a thing through a pledge, promise, or financial contribution. E.g., a sponsor of a Medical Study or a corporate sponsor of an event.", 
                                                                    "https://schema.org/sponsor")

    ProfileRow.create("teaches",            Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The item being described is intended to help a person learn the competency or learning outcome defined by the referenced term.", 
                                                                    "https://schema.org/teaches")

    ProfileRow.create("temporal",           Optional, ONE,          [   (Schema.DateTime, OR)
                                                                        (Schema.Text, END)], 
                                                                    """The "temporal" property can be used in cases where more specific properties (e.g. temporalCoverage, dateCreated, dateModified, datePublished) are not known to be appropriate.""", 
                                                                    "https://schema.org/temporal")

    ProfileRow.create("temporalCoverage",   Optional, ONE,          [   (Schema.DateTime, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    """The temporalCoverage of a CreativeWork indicates the period that the content applies to, i.e. that it describes, either as a DateTime or as a textual string indicating a time period in ISO 8601 time interval format. In the case of a Dataset it will typically indicate the relevant time period in a precise notation (e.g. for a 2011 census dataset, the year 2011 would be written "2011/2012"). Other forms of content, e.g. ScholarlyArticle, Book, TVSeries or TVEpisode, may indicate their temporalCoverage in broader terms - textually or via well-known URL. Written works such as books may sometimes have precise temporal coverage too, e.g. a work set in 1939 - 1945 can be indicated in ISO 8601 interval format format via "1939/1945". Open-ended date ranges can be written with ".." in place of the end date. For example, "2015-11/.." indicates a range beginning in November 2015 and with no specified final date. This is tentative and might be updated in future when ISO 8601 is officially updated. Supersedes datasetTimeInterval.""", 
                                                                    "https://schema.org/temporalCoverage")

    ProfileRow.create("text",               Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "The textual content of this CreativeWork.", 
                                                                    "https://schema.org/text")

    ProfileRow.create("thumbnail",          Optional, ONE,          [   (Schema.ImageObject, END)], 
                                                                    "Thumbnail image for an image or video. ", 
                                                                    "https://schema.org/text")

    ProfileRow.create("thumbnailUrl",       Optional, ONE,          [   (Schema.URL, END)], 
                                                                    "A thumbnail image relevant to the Thing.", 
                                                                    "https://schema.org/thumbnailUrl")

    ProfileRow.create("timeRequired",       Optional, ONE,          [   (Schema.Duration, END)], 
                                                                    "Approximate or typical time it takes to work with or through this learning resource for the typical intended target audience.", 
                                                                    "https://schema.org/timeRequired")

    ProfileRow.create("translationOfWork",  Optional, ONE,          [   (Schema.CreativeWork, END)], 
                                                                    "The work that this work has been translated from. E.g. ???? is a translationOf 'On the Origin of Species'. Inverse property: workTranslation.", 
                                                                    "https://schema.org/translationOfWork")

    ProfileRow.create("translator",         Optional, MANY,         [   (Schema.Person, OR)
                                                                        (Schema.Organization, END)], 
                                                                    "Organization or person who adapts a creative work to different languages, regional differences, and technical requirements of a target market, or that translates during some event.", 
                                                                    "https://schema.org/translator")

    ProfileRow.create("typicalAgeRange",    Optional, ONE,          [   (Schema.Text, END)], 
                                                                    "The typical expected age range, e.g., '7-9', '11-'.", 
                                                                    "https://schema.org/typicalAgeRange")

    ProfileRow.create("usageInfo",          Optional, ONE,          [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)], 
                                                                    "The schema.org usageInfo property indicates further information about a CreativeWork. This property is applicable both to works that are freely available and to those that require payment or other transactions. It can reference additional information, e.g., community expectations on preferred linking and citation conventions, as well as purchasing details. For something that can be commercially licensed, usageInfo can provide detailed, resource-specific information about licensing options.\n\nThis property can be used alongside the license property which indicates license(s) applicable to some piece of content. The usageInfo property can provide information about other licensing options, e.g., acquiring commercial usage rights for an image that is also available under non-commercial creative commons licenses.", 
                                                                    "https://schema.org/usageInfo")


    ProfileRow.create("version",            Optional, ONE,          [   (Schema.Number, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The version of the CreativeWork embodied by a specified resource.", 
                                                                    "https://schema.org/version")

    ProfileRow.create("video",              Optional, MANY,         [   (Schema.Clip, OR)
                                                                        (Schema.VideoObject, END)], 
                                                                    "An embedded video object.", 
                                                                    "https://schema.org/video")

    ProfileRow.create("workExample",        Optional, MANY,         [   (Schema.CreativeWork, END)], 
                                                                    "Example/instance/realization/derivation of the concept of this creative work. E.g. the paperback edition, first edition, or e-book. Inverse property: exampleOfWork", 
                                                                    "https://schema.org/workExample")

    ProfileRow.create("workTranslation",    Optional, MANY,         [   (Schema.CreativeWork, END)], 
                                                                    "A work that is a translation of the content of this work. E.g. ??? has an English workTranslation 'Journey to the West', a German workTranslation 'Monkeys Pilgerfahrt' and a Vietnamese translation 'Tây du ký bình kh?o'. Inverse property: translationOfWork.", 
                                                                    "https://schema.org/workTranslation")

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
