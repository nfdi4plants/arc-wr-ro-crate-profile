module Domain

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
    static member toTableRow (renderSourceColumn:bool) (row:ProfileRow) =
        let expectedTypes = row.ExpectedType |> List.map (fun (t, c) -> sprintf "%s%s" (SchemaType.toLink t) (Conjunction.toString c)) |> String.concat ""
        if renderSourceColumn then
            sprintf 
                "| **`%s`** | %s | %s | %s | %s | %s |" 
                row.Property 
                (Required.toString row.Required) 
                (Cardinality.toString row.Cardinality) 
                expectedTypes 
                row.Description 
                row.SourceProfile 
        else
            sprintf 
                "| **`%s`** | %s | %s | %s | %s |" 
                row.Property 
                (Required.toString row.Required) 
                (Cardinality.toString row.Cardinality) 
                expectedTypes 
                row.Description 

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
    let DataDownload = { Name = "DataDownload"; Domain = "schema.org"; Link = "https://schema.org/DataDownload" }
    let DataCatalog = { Name = "DataCatalog"; Domain = "schema.org"; Link = "https://schema.org/DataCatalog" }
    let Property = { Name = "Property"; Domain = "schema.org"; Link = "https://schema.org/Property" }
    let StatisticalVariable = { Name = "StatisticalVariable"; Domain = "schema.org"; Link = "https://schema.org/StatisticalVariable" }
    let CreateAction = { Name = "CreateAction"; Domain = "schema.org"; Link = "https://schema.org/CreateAction" }

module BioSchemas =
    let ComputationalWorkflow = { Name = "ComputationalWorkflow"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/ComputationalWorkflow" }
    let LabProtocol = { Name = "LabProtocol"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/LabProtocol" }
    let FormalParameter = { Name = "FormalParameter"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/FormalParameter" }
    let LabProcess = { Name = "LabProcess"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/LabProcess/0.1-DRAFT" }

module WorkflowRunProfile =
    let ProcessRun = { Name = "ProcessRun"; Domain = "workflow-run-crate"; Link = "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate" }
    let WorkflowRun = { Name = "WorkflowRun"; Domain = "workflow-run-crate"; Link = "https://www.researchobject.org/workflow-run-crate/profiles/workflow_run_crate/" }
    let FormalParameter = { Name = "FormalParameter"; Domain = "bioschemas.org"; Link = "https://bioschemas.org/types/FormalParameter" }

module MultiTypes =

    let WorkflowInvocation = { Name = "WorkflowInvocation"; Domain = ""; Link = "#workflow-invocation" }
    let WorkflowProtocol = { Name = "WorkflowProtocol"; Domain = ""; Link = "#workflow-protocol" }

type Profile = {
    Name: string
    Required: ProfileRow list
    Recommended: ProfileRow list
    Optional: ProfileRow list
} with
    static member create (name: string, required: ProfileRow list, ?recommended: ProfileRow list, ?optional: ProfileRow list) =
        { 
            Name = name
            Required = required
            Recommended = defaultArg recommended []
            Optional = defaultArg optional []
        }

let generateProfileTable (renderSourceColumn: bool) (profile: Profile) =
    let header = 
        if renderSourceColumn then
            [
                "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
                "|----------|----------|-------------|---------------|-------------|----------------|"
            ]
        else
            [
                "| Property | Required | Cardinality | Expected Type | Description |"
                "|----------|----------|-------------|---------------|-------------|"
            
            ]

    let subheaderRowTemplate (title:string) = 
        if renderSourceColumn then
            [$"| <h4>{title}</h4> | | | | | |"]
        else
            [$"| <h4>{title}</h4> | | | | |"]

    header
    @ subheaderRowTemplate "Required Properties"
    @ (profile.Required |> List.map (ProfileRow.toTableRow renderSourceColumn))
    @ subheaderRowTemplate "Recommended Properties"
    @ (profile.Recommended |> List.map (ProfileRow.toTableRow renderSourceColumn))
    @ subheaderRowTemplate "Optional Properties"
    @ (profile.Optional |> List.map (ProfileRow.toTableRow renderSourceColumn))
    |> String.concat System.Environment.NewLine