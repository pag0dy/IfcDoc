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
	[Guid("fdc6a245-73d0-49ab-af10-8bcd9e75d397")]
	public partial class IfcHalfSpaceSolid : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSurface _BaseSurface;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _AgreementFlag;
	
	
		public IfcHalfSpaceSolid()
		{
		}
	
		public IfcHalfSpaceSolid(IfcSurface __BaseSurface, Boolean __AgreementFlag)
		{
			this._BaseSurface = __BaseSurface;
			this._AgreementFlag = __AgreementFlag;
		}
	
		[Description("Surface defining side of half space.")]
		public IfcSurface BaseSurface { get { return this._BaseSurface; } set { this._BaseSurface = value;} }
	
		[Description("The agreement flag is TRUE if the normal to the BaseSurface points away from the " +
	    "material of the IfcHalfSpaceSolid. Otherwise it is FALSE.")]
		public Boolean AgreementFlag { get { return this._AgreementFlag; } set { this._AgreementFlag = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
