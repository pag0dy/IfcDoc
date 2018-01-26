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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("323bf335-cd8c-483b-bb95-0d441da83e76")]
	public partial class IfcTextureVertexList : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcParameterValue> _TexCoordsList = new List<IfcParameterValue>();
	
	
		public IfcTextureVertexList()
		{
		}
	
		public IfcTextureVertexList(IfcParameterValue[] __TexCoordsList)
		{
			this._TexCoordsList = new List<IfcParameterValue>(__TexCoordsList);
		}
	
		[Description("List of texture vertices defined by S-coordinate and T-coordinate.")]
		public IList<IfcParameterValue> TexCoordsList { get { return this._TexCoordsList; } }
	
	
	}
	
}
