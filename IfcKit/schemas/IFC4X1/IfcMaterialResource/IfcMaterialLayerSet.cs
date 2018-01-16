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
	[Guid("c1a5e8bc-cb6b-4466-8130-d2946ca1f8a0")]
	public partial class IfcMaterialLayerSet : IfcMaterialDefinition
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcMaterialLayer> _MaterialLayers = new List<IfcMaterialLayer>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _LayerSetName;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		[Description("Identification of the <em>IfcMaterialLayer</em>&rsquo;s from which the <em>IfcMat" +
	    "erialLayerSet</em> is composed.")]
		public IList<IfcMaterialLayer> MaterialLayers { get { return this._MaterialLayers; } }
	
		[Description("The name by which the <em>IfcMaterialLayerSet</em> is known.\r\n")]
		public IfcLabel? LayerSetName { get { return this._LayerSetName; } set { this._LayerSetName = value;} }
	
		[Description("Definition of the <em>IfcMaterialLayerSet</em> in descriptive terms.\r\n<blockquote" +
	    " class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; The attribute has been added at the" +
	    " end of attribute list.\r\n</blockquote>\r\n\r\n")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		public new IfcLengthMeasure TotalThickness { get { return new IfcLengthMeasure(); } }
	
	
	}
	
}
