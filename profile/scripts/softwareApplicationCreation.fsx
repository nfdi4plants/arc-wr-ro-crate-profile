#load "profileCreation.fsx"

open ProfileCreation

let optionalProfileProperties = [
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

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"software-application.generated.md"), 
    [
        "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
        "|----------|----------|-------------|---------------|-------------|----------------|"
    ]
    @ ["| <h4>Optional Properties</h4> | | | | | |"]
    @ (optionalProfileProperties |> List.map ProfileRow.toTableRow)
)