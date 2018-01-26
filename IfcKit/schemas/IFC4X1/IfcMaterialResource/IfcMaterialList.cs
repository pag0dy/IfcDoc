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


namespace BuildingSmart.IFC.IfcMaterialResource
{
	[Guid("e2c88e35-f4a8-464a-8816-1b1ae58202f5")]
	public partial class IfcMaterialList :
		BuildingSmart.IFC.IfcMaterialResource.IfcMaterialSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcMaterial> _Materials = new List<IfcMaterial>();
	
	
		public IfcMaterialList()
		{
		}
	
		public IfcMaterialList(IfcMaterial[] __Materials)
		{
			this._Materials = new List<IfcMaterial>(__Materials);
		}
	
		[Description("Materials used in a composition of substances.")]
		public IList<IfcMaterial> Materials { get { return this._Materials; } }
	
	
	}
	
}
