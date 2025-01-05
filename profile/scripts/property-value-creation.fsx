#load "profileCreation.fsx"

open ProfileCreation

let requiredProfileProperties = [
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

let recommendedProfileProperties = [
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

let optionalProfileProperties = [
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

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"property-value.generated.md"), 
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