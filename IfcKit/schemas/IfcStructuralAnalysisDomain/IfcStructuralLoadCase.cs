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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralLoadCase : IfcStructuralLoadGroup
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The self weight coefficients specify ratios at which loads due to weight of members shall be included in the load case.  These loads are not explicitly modeled as instances of <em>IfcStructuralAction</em>.  Instead they shall be calculated according to geometry, section, and material of each member.    <p>The three components of the self weight vector correspond with the x,y,z directions of the so-called global coordinates, i.e. the directions of the shared <em>ObjectPlacement</em> of all items in an <em>IfcStructuralAnalysisModel</em>.  For example, if the object placement defines a z axis which is upright like the <em>IfcProject</em>'s world coordinate system, then the self weight coefficients would typically be [0.,0.,-1.] in a load case of dead loads with self weight.</p>    <p>The overall coefficient in the inherited attribute <em>Coefficient</em> shall not be applied to <em>SelfWeightCoefficients</em> of the same instance of <em>IfcStructuralLoadCase</em>.  It only applies to actions and load groups which are grouped below the load case, not to the load case's computed self weight.")]
		[MinLength(3)]
		[MaxLength(3)]
		public IList<IfcRatioMeasure> SelfWeightCoefficients { get; protected set; }
	
	
		public IfcStructuralLoadCase(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLoadGroupTypeEnum __PredefinedType, IfcActionTypeEnum __ActionType, IfcActionSourceTypeEnum __ActionSource, IfcRatioMeasure? __Coefficient, IfcLabel? __Purpose, IfcRatioMeasure[] __SelfWeightCoefficients)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __PredefinedType, __ActionType, __ActionSource, __Coefficient, __Purpose)
		{
			this.SelfWeightCoefficients = new List<IfcRatioMeasure>(__SelfWeightCoefficients);
		}
	
	
	}
	
}
