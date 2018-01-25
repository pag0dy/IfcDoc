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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("e1ef998e-9c7f-4969-9371-b17f2cb38f14")]
	public partial class IfcAsset : IfcGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identification;
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcCostValue _OriginalValue;
	
		[DataMember(Order=2)] 
		[XmlElement]
		IfcCostValue _CurrentValue;
	
		[DataMember(Order=3)] 
		[XmlElement]
		IfcCostValue _TotalReplacementCost;
	
		[DataMember(Order=4)] 
		IfcActorSelect _Owner;
	
		[DataMember(Order=5)] 
		IfcActorSelect _User;
	
		[DataMember(Order=6)] 
		[XmlElement]
		IfcPerson _ResponsiblePerson;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcDate? _IncorporationDate;
	
		[DataMember(Order=8)] 
		[XmlElement]
		IfcCostValue _DepreciatedValue;
	
	
		[Description(@"A unique identification assigned to an asset that enables its differentiation from other assets.
	<blockquote class=""note"">NOTE&nbsp; The asset identifier is unique within the asset register. It differs from the globally unique id assigned to the instance of an entity populating a database.</blockquote>")]
		public IfcIdentifier? Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("The cost value of the asset at the time of purchase.")]
		public IfcCostValue OriginalValue { get { return this._OriginalValue; } set { this._OriginalValue = value;} }
	
		[Description("The current cost value of the asset.")]
		public IfcCostValue CurrentValue { get { return this._CurrentValue; } set { this._CurrentValue = value;} }
	
		[Description("The total cost of replacement of the asset.")]
		public IfcCostValue TotalReplacementCost { get { return this._TotalReplacementCost; } set { this._TotalReplacementCost = value;} }
	
		[Description("The name of the person or organization that \'owns\' the asset.")]
		public IfcActorSelect Owner { get { return this._Owner; } set { this._Owner = value;} }
	
		[Description("The name of the person or organization that \'uses\' the asset.")]
		public IfcActorSelect User { get { return this._User; } set { this._User = value;} }
	
		[Description(@"The person designated to be responsible for the asset.
	<blockquote class=""note"">NOTE&nbsp; In some regulations (for example, UK Health and Safety at Work Act, Electricity at Work Regulations), management of assets must have a person identified as being responsible and to whom regulatory, insurance and other organizations communicate. In places where there is not a legal requirement, the responsible person would be the asset manager but would not have a legal status.</blockquote>")]
		public IfcPerson ResponsiblePerson { get { return this._ResponsiblePerson; } set { this._ResponsiblePerson = value;} }
	
		[Description(@"The date on which an asset was incorporated into the works, installed, constructed, erected or completed.
	<blockquote class=""note"">NOTE&nbsp; This is the date on which an asset is considered to start depreciating.</blockquote>
	<blockquote class=""history"">IFC4 CHANGE&nbsp; Type changed from IfcDateTimeSelect.</blockquote>  
	")]
		public IfcDate? IncorporationDate { get { return this._IncorporationDate; } set { this._IncorporationDate = value;} }
	
		[Description("The current value of an asset within the accounting rules and procedures of an or" +
	    "ganization.")]
		public IfcCostValue DepreciatedValue { get { return this._DepreciatedValue; } set { this._DepreciatedValue = value;} }
	
	
	}
	
}
