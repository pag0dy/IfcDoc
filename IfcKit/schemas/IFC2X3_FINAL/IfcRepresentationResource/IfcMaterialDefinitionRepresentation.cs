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

using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("81a4cca3-7170-44c2-95ec-7a697d45e647")]
	public partial class IfcMaterialDefinitionRepresentation : IfcProductRepresentation
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcMaterial _RepresentedMaterial;
	
	
		public IfcMaterialDefinitionRepresentation()
		{
		}
	
		public IfcMaterialDefinitionRepresentation(IfcLabel? __Name, IfcText? __Description, IfcRepresentation[] __Representations, IfcMaterial __RepresentedMaterial)
			: base(__Name, __Description, __Representations)
		{
			this._RepresentedMaterial = __RepresentedMaterial;
		}
	
		[Description("Reference to the material to which the representation applies.")]
		public IfcMaterial RepresentedMaterial { get { return this._RepresentedMaterial; } set { this._RepresentedMaterial = value;} }
	
	
	}
	
}
