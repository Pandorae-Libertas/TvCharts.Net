var src = document.createElement("script");
src.setAttribute("src", "./_content/TvCharts.Net/js/lightweight-charts.js");
document.getElementsByTagName("head")[0].appendChild(src);

window.charts = {};
window.series = {};

export function loadChart(elementReference, elementReferenceId, templateOptions) {

// Create the chart canvas
window.charts[elementReferenceId] = LightweightCharts.createChart(elementReference, {
layout: {
backgroundColor: templateOptions.backgroundColor,
textColor: templateOptions.textColor,
},
});

// Make Chart Responsive with screen resize
new ResizeObserver(entries => {
if (entries.length === 0 || entries[0].target !== elementReference) { return; }

const newRect = entries[0].contentRect;

window.charts[elementReferenceId].applyOptions({ height: newRect.height, width: newRect.width });
}).observe(elementReference);

// Fit the timescale to fit the content
window.charts[elementReferenceId].timeScale().fitContent();
}

export function updateSeriesData(seriesId, seriesData) {
window.series[seriesId].setData(seriesData);
}
export function addCandlestickSeries(elementReferenceId, seriesId, seriesData) {

window.series[seriesId] = window.charts[elementReferenceId].addCandlestickSeries();
window.series[seriesId].setData(seriesData);
}
export function addLineSeries(elementReferenceId, seriesId, seriesData) {

window.series[seriesId] = window.charts[elementReferenceId].addLineSeries();
window.series[seriesId].setData(seriesData);
}
export function addAreaSeries(elementReferenceId, seriesId, seriesData) {

window.series[seriesId] = window.charts[elementReferenceId].addAreaSeries();
window.series[seriesId].setData(seriesData);
}
export function addHistogramSeries(elementReferenceId, seriesId, seriesData) {

window.series[seriesId] = window.charts[elementReferenceId].addHistogramSeries({
priceFormat: {
type: 'volume',
},
priceScaleId: '',
scaleMargins: {
top: 0.8,
bottom: 0,
}
});
window.series[seriesId].setData(seriesData);
}