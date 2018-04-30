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

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcTextureVertex
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The first coordinate[1] is the S, the second coordinate[2] is the T parameter value.")]
		[Required()]
		[MinLength(2)]
		[MaxLength(2)]
		public IList<IfcParameterValue> Coordinates { get; protected set; }
	
	
		public IfcTextureVertex(IfcParameterValue[] __Coordinates)
		{
			this.Coordinates = new List<IfcParameterValue>(__Coordinates);
		}
	
	
	}
	
}
