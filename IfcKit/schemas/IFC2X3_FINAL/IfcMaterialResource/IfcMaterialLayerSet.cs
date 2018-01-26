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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("f72fc8ce-1ae3-4ab8-abe6-48c801c4cfbb")]
	public partial class IfcMaterialLayerSet :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcMaterialLayer> _MaterialLayers = new List<IfcMaterialLayer>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _LayerSetName;
	
	
		public IfcMaterialLayerSet()
		{
		}
	
		public IfcMaterialLayerSet(IfcMaterialLayer[] __MaterialLayers, IfcLabel? __LayerSetName)
		{
			this._MaterialLayers = new List<IfcMaterialLayer>(__MaterialLayers);
			this._LayerSetName = __LayerSetName;
		}
	
		[Description("Identification of the layers from which the material layer set is composed.")]
		public IList<IfcMaterialLayer> MaterialLayers { get { return this._MaterialLayers; } }
	
		[Description("The name by which the material layer set is known.")]
		public IfcLabel? LayerSetName { get { return this._LayerSetName; } set { this._LayerSetName = value;} }
	
		public new IfcLengthMeasure TotalThickness { get { return new IfcLengthMeasure(); } }
	
	
	}
	
}
