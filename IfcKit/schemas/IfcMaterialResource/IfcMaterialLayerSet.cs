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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialLayerSet :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order = 0)] 
		[Description("Identification of the layers from which the material layer set is composed.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcMaterialLayer> MaterialLayers { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The name by which the material layer set is known.")]
		public IfcLabel? LayerSetName { get; set; }
	
	
		public IfcMaterialLayerSet(IfcMaterialLayer[] __MaterialLayers, IfcLabel? __LayerSetName)
		{
			this.MaterialLayers = new List<IfcMaterialLayer>(__MaterialLayers);
			this.LayerSetName = __LayerSetName;
		}
	
		public new IfcLengthMeasure TotalThickness { get { return new IfcLengthMeasure(); } }
	
	
	}
	
}
