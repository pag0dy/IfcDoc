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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcBooleanResult : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcCsgSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The Boolean operator used in the operation to create the result.")]
		[Required()]
		public IfcBooleanOperator Operator { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The first operand to be operated upon by the Boolean operation.")]
		[Required()]
		public IfcBooleanOperand FirstOperand { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The second operand specified for the operation.")]
		[Required()]
		public IfcBooleanOperand SecondOperand { get; set; }
	
	
		public IfcBooleanResult(IfcBooleanOperator __Operator, IfcBooleanOperand __FirstOperand, IfcBooleanOperand __SecondOperand)
		{
			this.Operator = __Operator;
			this.FirstOperand = __FirstOperand;
			this.SecondOperand = __SecondOperand;
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
