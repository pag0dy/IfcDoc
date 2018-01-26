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

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("681640e8-23dd-4876-8e42-74dc6334e9bd")]
	public partial class IfcAppliedValueRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAppliedValue _ComponentOfTotal;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcAppliedValue> _Components = new HashSet<IfcAppliedValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcArithmeticOperatorEnum _ArithmeticOperator;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		public IfcAppliedValueRelationship()
		{
		}
	
		public IfcAppliedValueRelationship(IfcAppliedValue __ComponentOfTotal, IfcAppliedValue[] __Components, IfcArithmeticOperatorEnum __ArithmeticOperator, IfcLabel? __Name, IfcText? __Description)
		{
			this._ComponentOfTotal = __ComponentOfTotal;
			this._Components = new HashSet<IfcAppliedValue>(__Components);
			this._ArithmeticOperator = __ArithmeticOperator;
			this._Name = __Name;
			this._Description = __Description;
		}
	
		[Description("The applied value (total or subtotal) of which the value being considered is a co" +
	    "mponent.")]
		public IfcAppliedValue ComponentOfTotal { get { return this._ComponentOfTotal; } set { this._ComponentOfTotal = value;} }
	
		[Description("Applied values that are components of another applied value and from which that a" +
	    "pplied value may be deduced.")]
		public ISet<IfcAppliedValue> Components { get { return this._Components; } }
	
		[Description("The arithmetic operator applied in an applied value relationship.")]
		public IfcArithmeticOperatorEnum ArithmeticOperator { get { return this._ArithmeticOperator; } set { this._ArithmeticOperator = value;} }
	
		[Description("A name used to identify or qualify the applied value relationship.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about an applied value relati" +
	    "onship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
