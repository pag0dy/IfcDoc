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
	[Guid("c49fa2f9-55a1-4a45-9f3c-ca8a7106f785")]
	public abstract partial class IfcMaterialUsageDefinition :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[InverseProperty("RelatingMaterial")] 
		ISet<IfcRelAssociatesMaterial> _AssociatedTo = new HashSet<IfcRelAssociatesMaterial>();
	
	
		[Description("<EPM-HTML>\r\nUse of the <em>IfcMaterialUsageDefinition</em> subtypes within the ma" +
	    "terial association of an element occurrence. The association is established by t" +
	    "he <em>IfcRelAssociatesMaterial</em> relationship.\r\n</EPM-HTML>")]
		public ISet<IfcRelAssociatesMaterial> AssociatedTo { get { return this._AssociatedTo; } }
	
	
	}
	
}
