namespace TemplateEngine
{
    public class TemplateEngine
    {
        private string template;
        private Dictionary<string, string> variables = new Dictionary<string, string>();

        public string Evaluate()
        {
            string result = this.template;
            foreach (var variable in variables)
            {
                result = result.Replace("{" + variable.Key + "}", variable.Value);
            }
            return result;
        }

        public void setTemplate(string template)
        {
            this.template = template;
        }

        public void setVariable(string name, string value)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = value;
            }
            else
            {
                variables.Add(name, value);
            }
        }
    }
}
