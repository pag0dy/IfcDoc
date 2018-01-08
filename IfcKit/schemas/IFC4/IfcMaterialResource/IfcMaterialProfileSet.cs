// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("e0fca8fd-d265-44c8-a538-722ea9b7a1a2")]
	public partial class IfcMaterialProfileSet : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IList<IfcMaterialProfile> _MaterialProfiles = new List<IfcMaterialProfile>();
	
		[DataMember(Order=3)] 
		[XmlElement("IfcCompositeProfileDef")]
		IfcCompositeProfileDef _CompositeProfile;
	
	
		[Description("<EPM-HTML>\r\nThe name by which the material profile set is known.\r\n</EPM-HTML>")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Definition of the material profile set in descriptive terms.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>\r\nIdentification of the profiles from which the material profile set is" +
	    " composed.\r\n</EPM-HTML>")]
		public IList<IfcMaterialProfile> MaterialProfiles { get { return this._MaterialProfiles; } }
	
		[Description(@"<EPM-HTML>
	Reference to the composite profile definition for which this material profile set associates material to each of its individual profiles. If only a single material profile is used (the most typical case) then no <em>CompositeProfile</em> is asserted.
	
	<blockquote class=""note"">NOTE&nbsp; The referenced <em>IfcCompositeProfileDef</em> instance shall be composed of all of the <em>IfcProfileDef</em> instances which are used via the MaterialProfiles list in the current <em>IfcMaterialProfileSet</em>.
	</blockquote>
	
	</EPM-HTML>")]
		public IfcCompositeProfileDef CompositeProfile { get { return this._CompositeProfile; } set { this._CompositeProfile = value;} }
	
	
	}
	
}
