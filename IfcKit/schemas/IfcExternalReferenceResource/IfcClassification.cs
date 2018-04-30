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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcClassification
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Source (or publisher) for this classification.")]
		[Required()]
		public IfcLabel Source { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The edition or version of the classification system from which the classification notation is derived.")]
		[Required()]
		public IfcLabel Edition { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The date on which the edition of the classification used became valid.  NOTE: The indication of edition may be sufficient to identify the classification source uniquely but the edition date is provided as an optional attribute to enable more precise identification where required.")]
		public IfcCalendarDate EditionDate { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The name or label by which the classification used is normally known.  NOTE: Examples of names include CI/SfB, Masterformat, BSAB, Uniclass, STABU etc.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[InverseProperty("ItemOf")] 
		[Description("Classification items that are classified by the classification.")]
		public ISet<IfcClassificationItem> Contains { get; protected set; }
	
	
		public IfcClassification(IfcLabel __Source, IfcLabel __Edition, IfcCalendarDate __EditionDate, IfcLabel __Name)
		{
			this.Source = __Source;
			this.Edition = __Edition;
			this.EditionDate = __EditionDate;
			this.Name = __Name;
			this.Contains = new HashSet<IfcClassificationItem>();
		}
	
	
	}
	
}
