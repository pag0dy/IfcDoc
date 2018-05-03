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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextureVertexList : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("List of texture vertices defined by S-coordinate and T-coordinate.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcParameterValue> TexCoordsList { get; protected set; }
	
	
		public IfcTextureVertexList(IfcParameterValue[] __TexCoordsList)
		{
			this.TexCoordsList = new List<IfcParameterValue>(__TexCoordsList);
		}
	
	
	}
	
}
