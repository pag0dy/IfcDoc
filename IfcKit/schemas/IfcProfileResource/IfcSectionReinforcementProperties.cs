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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	public partial class IfcSectionReinforcementProperties : IfcPreDefinedProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The start position in longitudinal direction for the section reinforcement properties.")]
		[Required()]
		public IfcLengthMeasure LongitudinalStartPosition { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The end position in longitudinal direction for the section reinforcement properties.")]
		[Required()]
		public IfcLengthMeasure LongitudinalEndPosition { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The position for the section reinforcement properties in transverse direction.")]
		public IfcLengthMeasure? TransversePosition { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The role, purpose or usage of the reinforcement, i.e. the kind of loads and stresses it is intended to carry, defined for the section reinforcement properties.")]
		[Required()]
		public IfcReinforcingBarRoleEnum ReinforcementRole { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("Definition of the cross section profile and longitudinal section type.")]
		[Required()]
		public IfcSectionProperties SectionDefinition { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The set of reinforcment properties attached to a section reinforcement properties definition.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcReinforcementBarProperties> CrossSectionReinforcementDefinitions { get; protected set; }
	
	
		public IfcSectionReinforcementProperties(IfcLengthMeasure __LongitudinalStartPosition, IfcLengthMeasure __LongitudinalEndPosition, IfcLengthMeasure? __TransversePosition, IfcReinforcingBarRoleEnum __ReinforcementRole, IfcSectionProperties __SectionDefinition, IfcReinforcementBarProperties[] __CrossSectionReinforcementDefinitions)
		{
			this.LongitudinalStartPosition = __LongitudinalStartPosition;
			this.LongitudinalEndPosition = __LongitudinalEndPosition;
			this.TransversePosition = __TransversePosition;
			this.ReinforcementRole = __ReinforcementRole;
			this.SectionDefinition = __SectionDefinition;
			this.CrossSectionReinforcementDefinitions = new HashSet<IfcReinforcementBarProperties>(__CrossSectionReinforcementDefinitions);
		}
	
	
	}
	
}
