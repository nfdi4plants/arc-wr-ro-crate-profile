module SoftwareApplication
open Domain

let requiredProfileProperties = [
    ProfileRow.create("@id",                      Required, ONE,         [   (IRI, END)], 
                                                                             """SHOULD be an absolute URI, but MAY be a relative URI to a data entity in the crate (e.g. "bin/simulation4") or a local identifier for tools that are not otherwise described on the web (e.g. "#statistical-analysis")""", 
                                                                             "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("@type",                    Required, MANY,        [   (Schema.SoftwareApplication, OR)
                                                                             (Schema.SoftwareSourceCode, OR)
                                                                             (BioSchemas.ComputationalWorkflow, END)], 
                                                                             "SHOULD include SoftwareApplication, SoftwareSourceCode or ComputationalWorkflow", 
                                                                             "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
]

let recommendedProfileProperties = [
// name, url and softwareVersion are Required according to https://www.researchobject.org/ro-crate/specification/1.1/workflows.html, but recommended
// according to https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate
    ProfileRow.create("name",                     Recommended, ONE,         [   (Schema.Text, END)], 
                                                                             "A human readable name for the tool in general (not just how it was used here)", 
                                                                             "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("url",                      Recommended, ONE,         [   (Schema.URL, END)], 
                                                                             "Homepage, documentation or source for the tool", 
                                                                             "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("softwareVersion",          Recommended, ONE,         [   (Schema.Text, END)], 
                                                                             "Version of the software instance.", 
                                                                             "https://schema.org/SoftwareApplication")

]

let optionalProfileProperties = [
    ProfileRow.create("version",                  Optional, ONE,         [   (Schema.Text, END)], 
                                                                             "The version string for the software application. In the case of a SoftwareApplication, this MAY be provided via the more specific softwareVersion. SoftwareApplication entities SHOULD NOT specify both version and softwareVersion: in this case, consumers SHOULD prioritize softwareVersion. In order to facilitate comparison attempts by consumers, it is RECOMMENDED to specify a machine-readable version string if available (see for instance Python's PEP 440).", 
                                                                             "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate/")
    ProfileRow.create("applicationCategory",      Optional, MANY,        [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Type of software application, e.g. 'Game, Multimedia'.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("downloadUrl",              Optional, MANY,        [   (Schema.URL, END)], 
                                                                             "If the file can be downloaded, URL to download the binary.", 
                                                                             "https://schema.org/SoftwareApplication")
    ProfileRow.create("softwareRequirements",     Optional, MANY,        [   (Schema.Text, OR)
                                                                             (Schema.URL, END)], 
                                                                             "Component dependency requirements for application. This includes runtime environments and shared libraries that are not included in the application distribution package, but required to run the application (examples: DirectX, Java or .NET runtime). Supersedes requirements.", 
                                                                             "https://schema.org/SoftwareApplication")
]

let profile = Profile.create(
    name = "SoftwareApplication",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)