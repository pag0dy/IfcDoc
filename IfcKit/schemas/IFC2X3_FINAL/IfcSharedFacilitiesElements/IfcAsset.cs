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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("96432cf6-3e4e-4f11-9aaa-6876ce228ef2")]
	public partial class IfcAsset : IfcGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _AssetID;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcCostValue _OriginalValue;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcCostValue _CurrentValue;
	
		[DataMember(Order=3)] 
		[Required()]
		IfcCostValue _TotalReplacementCost;
	
		[DataMember(Order=4)] 
		[Required()]
		IfcActorSelect _Owner;
	
		[DataMember(Order=5)] 
		[Required()]
		IfcActorSelect _User;
	
		[DataMember(Order=6)] 
		[Required()]
		IfcPerson _ResponsiblePerson;
	
		[DataMember(Order=7)] 
		[Required()]
		IfcCalendarDate _IncorporationDate;
	
		[DataMember(Order=8)] 
		[Required()]
		IfcCostValue _DepreciatedValue;
	
	
		public IfcAsset()
		{
		}
	
		public IfcAsset(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __AssetID, IfcCostValue __OriginalValue, IfcCostValue __CurrentValue, IfcCostValue __TotalReplacementCost, IfcActorSelect __Owner, IfcActorSelect __User, IfcPerson __ResponsiblePerson, IfcCalendarDate __IncorporationDate, IfcCostValue __DepreciatedValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._AssetID = __AssetID;
			this._OriginalValue = __OriginalValue;
			this._CurrentValue = __CurrentValue;
			this._TotalReplacementCost = __TotalReplacementCost;
			this._Owner = __Owner;
			this._User = __User;
			this._ResponsiblePerson = __ResponsiblePerson;
			this._IncorporationDate = __IncorporationDate;
			this._DepreciatedValue = __DepreciatedValue;
		}
	
		[Description(@"A unique identification assigned to an asset that enables its differentiation from other assets.
	NOTE: The asset identifier is unique within the asset register. It differs from the globally unique id assigned to the instance of an entity populating a database")]
		public IfcIdentifier AssetID { get { return this._AssetID; } set { this._AssetID = value;} }
	
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
	NOTE: In (e.g.) UK Law (Health and Safety at Work Act, Electricity at Work Regulations, and others), management of assets must have a person identified as being responsible and to whom regulatory, insurance and other organizations communicate. In places where there is not a legal requirement, the responsible person would be the asset manager but would not have a legal status.")]
		public IfcPerson ResponsiblePerson { get { return this._ResponsiblePerson; } set { this._ResponsiblePerson = value;} }
	
		[Description("The date on which an asset was incorporated into the works, installed, constructe" +
	    "d, erected or completed.\r\nNOTE: This is the date on which an asset is considered" +
	    " to start depreciating.")]
		public IfcCalendarDate IncorporationDate { get { return this._IncorporationDate; } set { this._IncorporationDate = value;} }
	
		[Description("The current value of an asset within the accounting rules and procedures of an or" +
	    "ganization.")]
		public IfcCostValue DepreciatedValue { get { return this._DepreciatedValue; } set { this._DepreciatedValue = value;} }
	
	
	}
	
}
