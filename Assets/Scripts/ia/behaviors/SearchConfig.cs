using System.Collections.Generic;

public class SearchConfig {
    public List<string> searchTypes = new List<string>();
    public IAState.EventAction doWhenView;
    public IAState.EventAction doWhenAlert;

    public SearchConfig(string searchType, IAState.EventAction doWhenLocate, IAState.EventAction doWhenAlert) {
        this.searchTypes.Add(searchType);
        this.doWhenView = doWhenLocate;
        this.doWhenAlert = doWhenAlert;
    }

    public IAState.EventAction getDoWhenLocate() {
        return doWhenView;
    }

    public IAState.EventAction getDoWhenAlert() {
        return this.doWhenAlert;
    }

    public List<string> getSearchClass() {
        return searchTypes;
    }
}