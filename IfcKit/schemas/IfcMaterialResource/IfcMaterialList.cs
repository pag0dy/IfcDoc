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


namespace BuildingSmart.IFC.IfcMaterialResource
{
	public partial class IfcMaterialList :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order = 0)] 
		[Description("Materials used in a composition of substances.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcMaterial> Materials { get; protected set; }
	
	
		public IfcMaterialList(IfcMaterial[] __Materials)
		{
			this.Materials = new List<IfcMaterial>(__Materials);
		}
	
	
	}
	
}
