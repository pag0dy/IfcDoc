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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("84f86007-fd9d-4f1b-8dd0-be2656acf7f1")]
	public partial class IfcClassification
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Source;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Edition;
	
		[DataMember(Order=2)] 
		IfcCalendarDate _EditionDate;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[InverseProperty("ItemOf")] 
		ISet<IfcClassificationItem> _Contains = new HashSet<IfcClassificationItem>();
	
	
		[Description("Source (or publisher) for this classification.")]
		public IfcLabel Source { get { return this._Source; } set { this._Source = value;} }
	
		[Description("The edition or version of the classification system from which the classification" +
	    " notation is derived.")]
		public IfcLabel Edition { get { return this._Edition; } set { this._Edition = value;} }
	
		[Description(@"The date on which the edition of the classification used became valid.
	NOTE: The indication of edition may be sufficient to identify the classification source uniquely but the edition date is provided as an optional attribute to enable more precise identification where required.")]
		public IfcCalendarDate EditionDate { get { return this._EditionDate; } set { this._EditionDate = value;} }
	
		[Description("The name or label by which the classification used is normally known.\r\nNOTE: Exam" +
	    "ples of names include CI/SfB, Masterformat, BSAB, Uniclass, STABU etc.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Classification items that are classified by the classification.")]
		public ISet<IfcClassificationItem> Contains { get { return this._Contains; } }
	
	
	}
	
}
