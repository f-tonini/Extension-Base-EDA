//  Copyright 2016 North Carolina State University, Center for Geospatial Analytics & 
//  Forest Service Northern Research Station, Institute for Applied Ecosystem Studies
//  Authors:  Francesco Tonini, Brian R. Miranda, Chris Jones

using Landis.Utilities;
using System.Collections.Generic;

namespace Landis.Extension.BaseEDA
{
    /// <summary>
    /// Methods for working with the template for map filenames.
    /// </summary>
    public static class MapNames
    {
        public const string AgentNameVar = "agentName";
        public const string TimestepVar = "timestep";

        private static IDictionary<string, bool> knownVars;
        private static IDictionary<string, string> varValues;

        //---------------------------------------------------------------------
        static MapNames()
        {
            knownVars = new Dictionary<string, bool>();
            knownVars[AgentNameVar] = true;
            knownVars[TimestepVar] = true;

            varValues = new Dictionary<string, string>();
        }

        //---------------------------------------------------------------------
        public static void CheckTemplateVars(string template)
        {
            OutputPath.CheckTemplateVars(template, knownVars);
        }

        //---------------------------------------------------------------------
        public static string ReplaceTemplateVars(string template,      //WHY DO WE HAVE TWO DIFFERENT METHODS ReplaceTemplateVars()
                                                 string agentName,     //WITH SAME NAME BUT ONE EXTRA PARAMETER (LINES 37, 46)?
                                                 int    timestep)   
        {
            varValues[AgentNameVar] = agentName;
            varValues[TimestepVar] = timestep.ToString();
            return OutputPath.ReplaceTemplateVars(template, varValues);
        }
        //---------------------------------------------------------------------
        public static string ReplaceTemplateVars(string template,
                                                 string agentName)
        {
            varValues[AgentNameVar] = agentName;
            return OutputPath.ReplaceTemplateVars(template, varValues);
        }
        //---------------------------------------------------------------------
        public static string ReplaceTemplateVarsMetadata(string template,
                                                string agentName)
        {
            varValues[AgentNameVar] = agentName;
            varValues[TimestepVar] = "{timestep}";
            return OutputPath.ReplaceTemplateVars(template, varValues);
        }
        //---------------------------------------------------------------------
    }
}
