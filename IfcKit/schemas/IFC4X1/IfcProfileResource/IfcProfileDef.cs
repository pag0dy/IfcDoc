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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("6721f13a-680a-41f0-b994-52e18d901eb5")]
	public partial class IfcProfileDef :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcProfileTypeEnum _ProfileType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ProfileName;
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
	
		[InverseProperty("ProfileDefinition")] 
		[XmlElement("IfcProfileProperties")]
		ISet<IfcProfileProperties> _HasProperties = new HashSet<IfcProfileProperties>();
	
	
		[Description(@"Defines the type of geometry into which this profile definition shall be resolved, either a curve or a surface area. In case of curve the profile should be referenced by a swept surface, in case of area the profile should be referenced by a swept area solid.")]
		public IfcProfileTypeEnum ProfileType { get { return this._ProfileType; } set { this._ProfileType = value;} }
	
		[Description("Human-readable name of the profile, for example according to a standard profile t" +
	    "able. As noted above, machine-readable standardized profile designations should " +
	    "be provided in <em>IfcExternalReference.ItemReference</em>.\r\n")]
		public IfcLabel? ProfileName { get { return this._ProfileName; } set { this._ProfileName = value;} }
	
		[Description("Reference to external information, e.g. library, classification, or document info" +
	    "rmation, which is associated with the profile.\r\n<blockquote class=\"change-ifc2x4" +
	    "\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get { return this._HasExternalReference; } }
	
		[Description("Additional properties of the profile, for example mechanical properties.\r\n<blockq" +
	    "uote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute</blockquote>")]
		public ISet<IfcProfileProperties> HasProperties { get { return this._HasProperties; } }
	
	
	}
	
}
