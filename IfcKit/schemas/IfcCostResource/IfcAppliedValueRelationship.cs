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

namespace BuildingSmart.IFC.IfcCostResource
{
	public partial class IfcAppliedValueRelationship
	{
		[DataMember(Order = 0)] 
		[Description("The applied value (total or subtotal) of which the value being considered is a component.")]
		[Required()]
		public IfcAppliedValue ComponentOfTotal { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Applied values that are components of another applied value and from which that applied value may be deduced.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcAppliedValue> Components { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The arithmetic operator applied in an applied value relationship.")]
		[Required()]
		public IfcArithmeticOperatorEnum ArithmeticOperator { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("A name used to identify or qualify the applied value relationship.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("A description that may apply additional information about an applied value relationship.")]
		public IfcText? Description { get; set; }
	
	
		public IfcAppliedValueRelationship(IfcAppliedValue __ComponentOfTotal, IfcAppliedValue[] __Components, IfcArithmeticOperatorEnum __ArithmeticOperator, IfcLabel? __Name, IfcText? __Description)
		{
			this.ComponentOfTotal = __ComponentOfTotal;
			this.Components = new HashSet<IfcAppliedValue>(__Components);
			this.ArithmeticOperator = __ArithmeticOperator;
			this.Name = __Name;
			this.Description = __Description;
		}
	
	
	}
	
}
