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
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("d6b4f4cd-a0c3-4234-98ac-8d92cee7bcda")]
	public partial class IfcExtendedMaterialProperties : IfcMaterialProperties
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcProperty> _ExtendedProperties = new HashSet<IfcProperty>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
	
		[Description("The set of material properties defined by user for this material.")]
		public ISet<IfcProperty> ExtendedProperties { get { return this._ExtendedProperties; } }
	
		[Description("Description for the set of extended properties.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The name given to the set of extended properties.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
