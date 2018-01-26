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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("e7a73b70-71af-407a-a632-68e2de126223")]
	public partial class IfcImageTexture : IfcSurfaceTexture
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcURIReference _URLReference;
	
	
		public IfcImageTexture()
		{
		}
	
		public IfcImageTexture(IfcBoolean __RepeatS, IfcBoolean __RepeatT, IfcIdentifier? __Mode, IfcCartesianTransformationOperator2D __TextureTransform, IfcIdentifier[] __Parameter, IfcURIReference __URLReference)
			: base(__RepeatS, __RepeatT, __Mode, __TextureTransform, __Parameter)
		{
			this._URLReference = __URLReference;
		}
	
		[Description("Location, provided as an URI, at which the image texture is electronically publis" +
	    "hed.")]
		public IfcURIReference URLReference { get { return this._URLReference; } set { this._URLReference = value;} }
	
	
	}
	
}
