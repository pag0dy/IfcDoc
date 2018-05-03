// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialLayerSet : IfcMaterialDefinition
	{
		[DataMember(Order = 0)] 
		[Description("Identification of the <em>IfcMaterialLayer</em>&rsquo;s from which the <em>IfcMaterialLayerSet</em> is composed.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcMaterialLayer> MaterialLayers { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The name by which the <em>IfcMaterialLayerSet</em> is known.  ")]
		public IfcLabel? LayerSetName { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Definition of the <em>IfcMaterialLayerSet</em> in descriptive terms.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; The attribute has been added at the end of attribute list.  </blockquote>    ")]
		public IfcText? Description { get; set; }
	
	
		public IfcMaterialLayerSet(IfcMaterialLayer[] __MaterialLayers, IfcLabel? __LayerSetName, IfcText? __Description)
		{
			this.MaterialLayers = new List<IfcMaterialLayer>(__MaterialLayers);
			this.LayerSetName = __LayerSetName;
			this.Description = __Description;
		}
	
		public new IfcLengthMeasure TotalThickness { get { return new IfcLengthMeasure(); } }
	
	
	}
	
}
