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
    ProfileRow.create("additionalType",     Required, ONE,          [    (Schema.Text, OR)
                                                                         (Schema.URL, END)
                                                                    ], 
                                                                    "MUST be 'Workflow Protocol' or ontology term to identify it as a Workflow Protocol", 
                                                                    "**THIS PROFILE**")
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
]

let recommendedProfileProperties = [
    // properties mandatory in from https://bioschemas.org/profiles/ComputationalWorkflow
    // -> Recommended in our case means use these if you want to be compatible
    ProfileRow.create("input",              Recommended, MANY,      [   (BioSchemas.FormalParameter, END)], 
                                                                    "An input required to use the computational workflow (eg. Excel spreadsheet, BAM file)", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("output",             Recommended, MANY,      [   (BioSchemas.FormalParameter, END)], 
                                                                    "An output produced by the workflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("dct:conformsTo",     Recommended, SPECIFIC 1,[   (IRI, END)], 
                                                                    "Used to state the profiles that the markup relates to. MUST be 'https://bioschemas.org/profiles/ComputationalWorkflow/1.0-RELEASE'", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("creator",            Recommended, MANY,      [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The creator/author of this CreativeWork. This is the same as the Author property for CreativeWork.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("dateCreated",        Recommended, ONE,       [   (Schema.Date, OR)   
                                                                        (Schema.DateTime, END)
                                                                    ], 
                                                                    "The date on which the CreativeWork was created or the item was added to a DataFeed.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("license",            Recommended, MANY,      [   (Schema.CreativeWork, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A license document that applies to this content, typically indicated by URL.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("name",               Recommended, ONE,       [   (Schema.Text, END)], 
                                                                    "The name of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("programmingLanguage",Recommended, MANY,      [   (Schema.ComputerLanguage, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "The computer programming language, Scripts written in a programming language, as well as workflows, generally need a runtime; in RO-Crate the runtime SHOULD be indicated using a liberal interpretation of programmingLanguage", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("sdPublisher",        Recommended, ONE,       [   (Schema.Organization, OR)
                                                                        (Schema.Person, END)
                                                                    ], 
                                                                    "The host site for the ComputationalWorkflow", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("url",                Recommended, ONE,       [   (Schema.URL, END)], 
                                                                    "URL of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("version",            Recommended, ONE,       [   (Schema.Text, OR)
                                                                        (Schema.Number, END)
                                                                    ], 
                                                                    "Version is a release. The date modified may not warrant a release, but last date modified and access to all versions is important", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
]

let optionalProfileProperties = [

    // Optional props aggregate selected recommended props from underlying profiles

    // properties from https://bioschemas.org/profiles/ComputationalWorkflow
    ProfileRow.create("description",            Optional, ONE,      [   (Schema.Text, END)], 
                                                                    "A description of the item.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    ProfileRow.create("hasPart",                Optional, MANY,     [   (Schema.CreativeWork, END)], 
                                                                    "The tools/scripts that are (potentially) used by the ComputationalWorkflow when it is executed, The parts are not ordered; they normally correspond to steps in the workflow, there is no specified mapping.", 
                                                                    "https://bioschemas.org/profiles/ComputationalWorkflow")
    // properties from OUR LabProtocol profile
    // description is already part of ComputationalWorkflow profile
    ProfileRow.create("intendedUse",            Optional, ONE,      [   (Schema.DefinedTerm, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "The protocol type as an ontology term", 
                                                                    "isa-ro-crate-profile/LabProtocol")
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
]

let profile = Profile.create(
    name = "WorkflowProtocol",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)