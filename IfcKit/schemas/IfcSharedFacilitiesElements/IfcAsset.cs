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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public partial class IfcAsset : IfcGroup
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A unique identification assigned to an asset that enables its differentiation from other assets.  NOTE: The asset identifier is unique within the asset register. It differs from the globally unique id assigned to the instance of an entity populating a database")]
		[Required()]
		public IfcIdentifier AssetID { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The cost value of the asset at the time of purchase.")]
		[Required()]
		public IfcCostValue OriginalValue { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The current cost value of the asset.")]
		[Required()]
		public IfcCostValue CurrentValue { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The total cost of replacement of the asset.")]
		[Required()]
		public IfcCostValue TotalReplacementCost { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The name of the person or organization that 'owns' the asset.")]
		[Required()]
		public IfcActorSelect Owner { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The name of the person or organization that 'uses' the asset.")]
		[Required()]
		public IfcActorSelect User { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("The person designated to be responsible for the asset.  NOTE: In (e.g.) UK Law (Health and Safety at Work Act, Electricity at Work Regulations, and others), management of assets must have a person identified as being responsible and to whom regulatory, insurance and other organizations communicate. In places where there is not a legal requirement, the responsible person would be the asset manager but would not have a legal status.")]
		[Required()]
		public IfcPerson ResponsiblePerson { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("The date on which an asset was incorporated into the works, installed, constructed, erected or completed.  NOTE: This is the date on which an asset is considered to start depreciating.")]
		[Required()]
		public IfcCalendarDate IncorporationDate { get; set; }
	
		[DataMember(Order = 8)] 
		[Description("The current value of an asset within the accounting rules and procedures of an organization.")]
		[Required()]
		public IfcCostValue DepreciatedValue { get; set; }
	
	
		public IfcAsset(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __AssetID, IfcCostValue __OriginalValue, IfcCostValue __CurrentValue, IfcCostValue __TotalReplacementCost, IfcActorSelect __Owner, IfcActorSelect __User, IfcPerson __ResponsiblePerson, IfcCalendarDate __IncorporationDate, IfcCostValue __DepreciatedValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.AssetID = __AssetID;
			this.OriginalValue = __OriginalValue;
			this.CurrentValue = __CurrentValue;
			this.TotalReplacementCost = __TotalReplacementCost;
			this.Owner = __Owner;
			this.User = __User;
			this.ResponsiblePerson = __ResponsiblePerson;
			this.IncorporationDate = __IncorporationDate;
			this.DepreciatedValue = __DepreciatedValue;
		}
	
	
	}
	
}
