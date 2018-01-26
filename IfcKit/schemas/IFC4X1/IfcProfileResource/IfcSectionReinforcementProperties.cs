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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("1a1fbaec-082a-40cf-b33c-8bd3fe79b8e5")]
	public partial class IfcSectionReinforcementProperties : IfcPreDefinedProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _LongitudinalStartPosition;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _LongitudinalEndPosition;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLengthMeasure? _TransversePosition;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcReinforcingBarRoleEnum _ReinforcementRole;
	
		[DataMember(Order=4)] 
		[XmlElement]
		[Required()]
		IfcSectionProperties _SectionDefinition;
	
		[DataMember(Order=5)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcReinforcementBarProperties> _CrossSectionReinforcementDefinitions = new HashSet<IfcReinforcementBarProperties>();
	
	
		public IfcSectionReinforcementProperties()
		{
		}
	
		public IfcSectionReinforcementProperties(IfcLengthMeasure __LongitudinalStartPosition, IfcLengthMeasure __LongitudinalEndPosition, IfcLengthMeasure? __TransversePosition, IfcReinforcingBarRoleEnum __ReinforcementRole, IfcSectionProperties __SectionDefinition, IfcReinforcementBarProperties[] __CrossSectionReinforcementDefinitions)
		{
			this._LongitudinalStartPosition = __LongitudinalStartPosition;
			this._LongitudinalEndPosition = __LongitudinalEndPosition;
			this._TransversePosition = __TransversePosition;
			this._ReinforcementRole = __ReinforcementRole;
			this._SectionDefinition = __SectionDefinition;
			this._CrossSectionReinforcementDefinitions = new HashSet<IfcReinforcementBarProperties>(__CrossSectionReinforcementDefinitions);
		}
	
		[Description("The start position in longitudinal direction for the section reinforcement proper" +
	    "ties.")]
		public IfcLengthMeasure LongitudinalStartPosition { get { return this._LongitudinalStartPosition; } set { this._LongitudinalStartPosition = value;} }
	
		[Description("The end position in longitudinal direction for the section reinforcement properti" +
	    "es.")]
		public IfcLengthMeasure LongitudinalEndPosition { get { return this._LongitudinalEndPosition; } set { this._LongitudinalEndPosition = value;} }
	
		[Description("The position for the section reinforcement properties in transverse direction.")]
		public IfcLengthMeasure? TransversePosition { get { return this._TransversePosition; } set { this._TransversePosition = value;} }
	
		[Description("The role, purpose or usage of the reinforcement, i.e. the kind of loads and stres" +
	    "ses it is intended to carry, defined for the section reinforcement properties.")]
		public IfcReinforcingBarRoleEnum ReinforcementRole { get { return this._ReinforcementRole; } set { this._ReinforcementRole = value;} }
	
		[Description("Definition of the cross section profile and longitudinal section type.")]
		public IfcSectionProperties SectionDefinition { get { return this._SectionDefinition; } set { this._SectionDefinition = value;} }
	
		[Description("The set of reinforcment properties attached to a section reinforcement properties" +
	    " definition.")]
		public ISet<IfcReinforcementBarProperties> CrossSectionReinforcementDefinitions { get { return this._CrossSectionReinforcementDefinitions; } }
	
	
	}
	
}
