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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("411fdc4b-ec30-4513-b554-f7ce4a481085")]
	public partial class IfcBoxedHalfSpace : IfcHalfSpaceSolid
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcBoundingBox _Enclosure;
	
	
		public IfcBoxedHalfSpace()
		{
		}
	
		public IfcBoxedHalfSpace(IfcSurface __BaseSurface, Boolean __AgreementFlag, IfcBoundingBox __Enclosure)
			: base(__BaseSurface, __AgreementFlag)
		{
			this._Enclosure = __Enclosure;
		}
	
		[Description("The box which bounds the half space for computational purposes only.\r\n")]
		public IfcBoundingBox Enclosure { get { return this._Enclosure; } set { this._Enclosure = value;} }
	
	
	}
	
}
