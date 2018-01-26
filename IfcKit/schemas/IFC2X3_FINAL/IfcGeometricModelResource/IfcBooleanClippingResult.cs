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
	[Guid("c01775c6-92a1-49ef-8434-510b5db59e84")]
	public partial class IfcBooleanClippingResult : IfcBooleanResult
	{
	
		public IfcBooleanClippingResult()
		{
		}
	
		public IfcBooleanClippingResult(IfcBooleanOperator __Operator, IfcBooleanOperand __FirstOperand, IfcBooleanOperand __SecondOperand)
			: base(__Operator, __FirstOperand, __SecondOperand)
		{
		}
	
	
	}
	
}
