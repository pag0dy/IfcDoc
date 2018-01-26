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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("44ff2ba0-d8b9-466c-9dba-d297766c680f")]
	public partial class IfcMirroredProfileDef : IfcDerivedProfileDef
	{
	
		public IfcMirroredProfileDef()
		{
		}
	
		public IfcMirroredProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcProfileDef __ParentProfile, IfcCartesianTransformationOperator2D __Operator, IfcLabel? __Label)
			: base(__ProfileType, __ProfileName, __ParentProfile, __Operator, __Label)
		{
		}
	
		public new IfcCartesianTransformationOperator2D Operator { get { return null; } }
	
	
	}
	
}
