#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [

    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "A unique identifier for the dataset", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
    ProfileRow.create("conformsTo",         Required, ONE,          [   (Schema.CreativeWork, END)], 
                                                                    """MUST reference a CreativeWork entity with an @id URI that is consistent with the versioned Permalink of this document, e.g. {"@id": "https://w3id.org/ro/wfrun/process/0.4"}""", 
                                                                    "https://www.researchobject.org/workflow-run-crate/profiles/process_run_crate")
]
let optionalProfileProperties = [

    ProfileRow.create("distribution",       Optional, MANY,         [   (Schema.DataDownload, END)], 
                                                                    "A downloadable form of this dataset, at a specific location, in a specific format. This property can be repeated if different variations are available. There is no expectation that different downloadable distributions must contain exactly equivalent information (see also DCAT on this point). Different distributions might include or exclude different subsets of the entire dataset, for example.", 
                                                                    "https://schema.org/Dataset")

    ProfileRow.create("includedInDataCatalog", Optional, MANY,      [   (Schema.DataCatalog, END)], 
                                                                    "A data catalog which contains this dataset. Supersedes catalog, includedDataCatalog. Inverse property: dataset.", 
                                                                    "https://schema.org/Dataset")

    ProfileRow.create("issn",               Optional, MANY,         [   (Schema.Text, END)], 
                                                                    "The International Standard Serial Number (ISSN) that identifies this serial publication. You can repeat this property to identify different formats of, or the linking ISSN (ISSN-L) for, this serial publication.", 
                                                                    "https://schema.org/Dataset")

    ProfileRow.create("measurementMethod",  Optional, MANY,         [   (Schema.DefinedTerm, OR)
                                                                        (Schema.MeasurementMethodEnum, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A subproperty of measurementTechnique that can be used for specifying specific methods, in particular via MeasurementMethodEnum.", 
                                                                    "https://schema.org/Dataset")

    ProfileRow.create("measurementTechnique", Optional, MANY,       [   (Schema.DefinedTerm, OR)
                                                                        (Schema.MeasurementMethodEnum, OR)
                                                                        (Schema.Text, OR)
                                                                        (Schema.URL, END)], 
                                                                    "A technique, method or technology used in an Observation, StatisticalVariable or Dataset (or DataDownload, DataCatalog), corresponding to the method used for measuring the corresponding variable(s) (for datasets, described using variableMeasured; for Observation, a StatisticalVariable). Often but not necessarily each variableMeasured will have an explicit representation as (or mapping to) an property such as those defined in Schema.org, or other RDF vocabularies and 'knowledge graphs'. In that case the subproperty of variableMeasured called measuredProperty is applicable. The measurementTechnique property helps when extra clarification is needed about how a measuredProperty was measured. This is oriented towards scientific and scholarly dataset publication but may have broader applicability; it is not intended as a full representation of measurement, but can often serve as a high level summary for dataset discovery. For example, if variableMeasured is: molecule concentration, measurementTechnique could be: 'mass spectrometry' or 'nmr spectroscopy' or 'colorimetry' or 'immunofluorescence'. If the variableMeasured is 'depression rating', the measurementTechnique could be 'Zung Scale' or 'HAM-D' or 'Beck Depression Inventory'. If there are several variableMeasured properties recorded for some given data object, use a PropertyValue for each variableMeasured and attach the corresponding measurementTechnique. The value can also be from an enumeration, organized as a MeasurementMetholdEnumeration.", 
                                                                    "https://schema.org/Dataset")

    ProfileRow.create("variableMeasured",   Optional, MANY,         [   (Schema.Property, OR)
                                                                        (Schema.PropertyValue, OR)
                                                                        (Schema.StatisticalVariable, OR)
                                                                        (Schema.Text, END)], 
                                                                    "The variableMeasured property can indicate (repeated as necessary) the variables that are measured in some dataset, either described as text or as pairs of identifier and description using PropertyValue, or more explicitly as a StatisticalVariable.", 
                                                                    "https://schema.org/Dataset")
]

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"dataset.generated.md"), 
    [
        "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
        "|----------|----------|-------------|---------------|-------------|----------------|"
    ]
    @ ["| <h4>Required Properties</h4> | | | | | |"]
    @ (requiredProfileProperties |> List.map ProfileRow.toTableRow)
    @ ["| <h4>Optional Properties</h4> | | | | | |"]
    @ (optionalProfileProperties |> List.map ProfileRow.toTableRow)
)
