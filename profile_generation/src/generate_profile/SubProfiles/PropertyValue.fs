module PropertyValue
open Domain

let requiredProfileProperties = [
    ProfileRow.create("@id",                Required, ONE,          [   (IRI, END)], 
                                                                    "Used to distinguish the resource being described in JSON-LD. For other serialisations use the appropriate approach.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("@type",              Required, MANY,         [   (Schema.PropertyValue, END)], 
                                                                    "Schema.org class for the resource declared using JSON-LD syntax. For other serialisations please use the appropriate mechanism. While it is permissible to provide multiple types, it is preferred to use a single type.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("name",               Required, ONE,          [   (Schema.Text, END)], 
                                                                    "The name of the item.", 
                                                                    "https://schema.org/Thing")
]

let recommendedProfileProperties = [
    // Required -> Recommended
    ProfileRow.create("value",              Recommended, ONE,       [   (Schema.Boolean, OR)
                                                                        (Schema.Number, OR)
                                                                        (Schema.StructuredValue, OR)
                                                                        (Schema.Text, END)
                                                                    ], 
                                                                    "The value of a QuantitativeValue (including Observation) or property value node. For QuantitativeValue and MonetaryAmount, the recommended type for values is 'Number'. For PropertyValue, it can be 'Text', 'Number', 'Boolean', or 'StructuredValue'. Use values from 0123456789 [Add to Citavi project by ISBN] (Unicode 'DIGIT ZERO' (U+0030) to 'DIGIT NINE' (U+0039)) rather than superficially similar Unicode symbols. Use '.' (Unicode 'FULL STOP' (U+002E)) rather than ',' to indicate a decimal point. Avoid using these symbols as a readability separator.", 
                                                                    "https://schema.org/PropertyValue")
    ProfileRow.create("propertyID",         Recommended, ONE,       [   (Schema.Text, OR)
                                                                        (Schema.URL, END)
                                                                    ], 
                                                                    "A commonly used identifier for the characteristic represented by the property, e.g. a manufacturer or a standard code for a property. propertyID can be (1) a prefixed string, mainly meant to be used with standards for product properties; (2) a site-specific, non-prefixed string (e.g. the primary key of the property or the vendor-specific ID of the property), or (3) a URL indicating the type of the property, either pointing to an external vocabulary, or a Web resource that describes the property (e.g. a glossary entry). Standards bodies should promote a standard prefix for the identifiers of properties from their standards.", 
                                                                    "https://schema.org/PropertyValue")
]

let optionalProfileProperties = [
    // Recommended -> Optional
    // Recommended -> Optional
    ProfileRow.create("exampleOfWork",      Optional, ONE,          [   (IRI, END)], 
                                                                    "Identifier of the FormalParameter instance realized by this entity.", 
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
]

let profile = Profile.create(
    name = "PropertyValue",
    required = requiredProfileProperties,
    recommended = recommendedProfileProperties,
    optional = optionalProfileProperties
)