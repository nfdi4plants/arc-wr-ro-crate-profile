#load "profileCreation.fsx"

open ProfileCreation

let optionalProfileProperties = [
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

open System.IO

File.WriteAllLines(Path.Combine(__SOURCE_DIRECTORY__,"createive-work.generated.md"), 
    [
        "| Property | Required | Cardinality | Expected Type | Description | Source Profile |"
        "|----------|----------|-------------|---------------|-------------|----------------|"
    ]
    @ ["| <h4>Optional Properties</h4> | | | | | |"]
    @ (optionalProfileProperties |> List.map ProfileRow.toTableRow)
)
 