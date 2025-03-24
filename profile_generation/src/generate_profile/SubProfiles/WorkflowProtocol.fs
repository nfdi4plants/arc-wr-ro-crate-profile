module WorkflowProtocol
open Domain

let requiredProfileProperties = [
    // properties from https://bioschemas.org/profiles/ComputationalWorkflow
    ProfileRow.create("@context",           Required, ONE,          [   (Schema.URL , END)], 
                                                                    "Used to provide the context (namespaces) for the JSON-LD file. Not needed in other serialisations.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("@type",              Required, SPECIFIC 4,   [   (Schema.Text, AND)
                                                                        (Schema.SoftwareSourceCode, AND)
                                                                        (BioSchemas.ComputationalWorkflow, AND)
                                                                        (BioSchemas.LabProtocol, END) 
                                                                    ], 
                                                                    "Schema.org/Bioschemas class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "**THIS PROFILE**")
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("dct:conformsTo",     Required, SPECIFIC 2,   [   (IRI, END)], 
                                                                    "Used to state the profiles that the markup relates to. MUST be 'https://bioschemas.org/profiles/ComputationalWorkflow/1.0-RELEASE' AND `<insert our LabProtocol profile IRI here>`", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // properties from https://bioschemas.org/profiles/ComputationalWorkflow
]

let recommendedProfileProperties = [
    // Required -> Recommended
    ProfileRow.create("input",              Recommended, MANY,      [   (BioSchemas.FormalParameter, END)], 
                                                                    "An input required to use the computational workflow (eg. Excel spreadsheet, BAM file)", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("output",             Recommended, MANY,      [   (BioSchemas.FormalParameter, END)], 
                                                                    "An output produced by the workflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("creator",            Recommended, MANY,      [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The creator/author of this CreativeWork. This is the same as the Author property for CreativeWork.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("dateCreated",        Recommended, ONE,       [   (Schema.Date, OR)   
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "The date on which the CreativeWork was created or the item was added to a DataFeed.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("license",            Recommended, MANY,      [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A license document that applies to this content, typically indicated by URL.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("name",               Recommended, ONE,       [   (Schema.Text, END)], 
                                                                    "The name of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("programmingLanguage",Recommended, MANY,      [   (Schema.ComputerLanguage, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "The computer programming language, Scripts written in a programming language, as well as workflows, generally need a runtime; in RO-Crate the runtime SHOULD be indicated using a liberal interpretation of programmingLanguage", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("sdPublisher",        Recommended, ONE,       [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The host site for the ComputationalWorkflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("url",                Recommended, ONE,       [   (Schema.URL, END)], 
                                                                    "URL of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Required -> Recommended
    ProfileRow.create("version",            Recommended, ONE,       [   (Schema.Text, OR)
                                                                        (Schema.Number, END)
                                                                    ], 
                                                                    "Version is a release. The date modified may not warrant a release, but last date modified and access to all versions is important", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
]

let optionalProfileProperties = [

    // properties from https://bioschemas.org/profiles/ComputationalWorkflow
    // Recommended -> Optional
    ProfileRow.create("citation",               Optional, MANY,     [   (Schema.CreativeWork, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "A citation or reference to another creative work, such as another publication, web page, scholarly article, etc.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("contributor",            Optional, MANY,     [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "A secondary contributor to the CreativeWork or Event.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("creativeWorkStatus",     Optional, ONE,      [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "The status of a creative work in terms of its stage in a lifecycle. Example terms include Incomplete, Draft, Published, Obsolete. Some organizations define a set of terms for the stages of their publication lifecycle.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("description",            Optional, ONE,      [   (Schema.Text, END)], 
                                                                    "A description of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("documentation",          Optional, MANY,     [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Documentation describing the ComputationalWorkflow and its use.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("funding",                Optional, MANY,     [   (Schema.Grant, END)], 
                                                                    "The funding for the workflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("hasPart",                Optional, MANY,     [   (Schema.CreativeWork, END)], 
                                                                    "The tools/scripts that are (potentially) used by the ComputationalWorkflow when it is executed, The parts are not ordered; they normally correspond to steps in the workflow, there is no specified mapping.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("isBasedOn",              Optional, ONE,      [   (Schema.CreativeWork, OR)
                                                                        (Schema.Product, END)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "This is normally another ComputationalWorkflow, but may also be, for example, a paper or a lab protocol.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("keywords",               Optional, ONE,      [   (Schema.Text, END)], 
                                                                    "Keywords or tags used to describe this content. Multiple entries in a keywords list are typically delimited by commas.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("maintainer",             Optional, MANY,     [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "A maintainer of a Dataset, software package (SoftwareApplication), or other Project. A maintainer is a Person or Organization that manages contributions to, and/or publication of, some (typically complex) artifact. It is common for distributions of software and data to be based on \"upstream\" sources. When maintainer is applied to a specific version of something e.g. a particular version or packaging of a Dataset, it is always possible that the upstream source has a different maintainer. The isBasedOn property can be used to indicate such relationships between datasets to make the different maintenance roles clear. Similarly in the case of software, a package may have dedicated maintainers working on integration into software distributions such as Ubuntu, as well as upstream maintainers of the underlying work.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("producer",               Optional, MANY,     [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The person or organization who produced the workflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("publisher",              Optional, MANY,     [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "Where it came came from, e.g. Galaxy, github, or WF Hub if uploaded", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("runtimePlatform",        Optional, MANY,     [   (Schema.Text, END)], 
                                                                    "Runtime platform or script interpreter dependencies (Example - Java v1, Python2.3, .Net Framework 3.0). Supersedes runtime.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("softwareRequirements",   Optional, MANY,     [   (Schema.Text, END)], 
                                                                    "Renaming schema.org/requirements as softwareRequirements", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // Recommended -> Optional
    ProfileRow.create("targetProduct",          Optional, MANY,     [   (Schema.SoftwareApplication, END)], 
                                                                    "Target Operating System / Product to which the code applies. If applies to several versions, just the product name can be used.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // properties from OUR LabProtocol profile
    // description is already part of ComputationalWorkflow profile
    // Recommended -> Optional
    ProfileRow.create("intendedUse",            Optional, ONE,      [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The protocol type as an ontology term", 
                                                                    "isa-ro-crate-profile/LabProtocol")
    // name is already part of ComputationalWorkflow profile
    // properties from https://bioschemas.org/profiles/ComputationalWorkflow
    ProfileRow.create("alternateName",          Optional, MANY,     [   (Schema.Text, END)], 
                                                                    "An alias for the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("conditionsOfAccess",     Optional, ONE,      [   (Schema.Text, END)], 
                                                                    "Conditions that affect the availability of, or method(s) of access to, an item. Typically used for real world items such as an ArchiveComponent held by an ArchiveOrganization. This property is not suitable for use as a general Web access control mechanism. It is expressed only in natural language. For example \"Available by appointment from the Reading Room\" or \"Accessible only from logged-in accounts \".", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("dateModified",           Optional, ONE,      [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "The date on which the CreativeWork was most recently modified or when the item's entry was modified within a DataFeed.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("datePublished",          Optional, ONE,      [   (Schema.Date, OR)
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "Date of first broadcast/publication.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("encodingFormat",         Optional, MANY,     [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "Should be the type of the workflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("identifier",             Optional, MANY,     [   (Schema.Text, OR)
                                                                        (Schema.PropertyValue, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The identifier property represents any kind of identifier for any kind of Thing, such as ISBNs, GTIN codes, UUIDs etc. Schema.org provides dedicated properties for representing many of these, either as textual strings or as URL (URI) links. See background notes for more details.",
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("image",                  Optional, MANY,     [   (Schema.ImageObject, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "An image of the item. This can be a URL or a fully described ImageObject. It can be beneficial to show a diagram or sketch to explain the script/workflow. This may have been generated from a workflow management system, or drawn manually as a diagram.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // properties from OUR LabProtocol profile
    ProfileRow.create("comment",                Optional, MANY,     [   (Schema.Comment, END)], 
                                                                    "", 
                                                                    "isa-ro-crate-profile/LabProtocol")
    ProfileRow.create("computationalTool",      Optional, MANY,     [   (Schema.SoftwareApplication, OR)
                                                                        (Schema.DefinedTerm, OR)
                                                                        (Schema.PropertyValue, END)
                                                                    ], 
                                                                    "Software or tool used as part of the lab protocol to complete a part of it.", 
                                                                    "isa-ro-crate-profile/LabProtocol")
    // labEquipment makes no sense here:
    // reagent makes no sense here:
    // url is already part of ComputationalWorkflow profile
    // version is already part of ComputationalWorkflow profile
]

let profile = Profile.create(
    name = "WorkflowProtocol",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)